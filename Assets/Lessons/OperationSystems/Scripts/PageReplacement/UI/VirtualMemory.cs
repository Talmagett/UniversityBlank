using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.PageReplacement.UI
{
    public class VirtualMemory : MonoBehaviour
    {
        [SerializeField] private HardDisk hardDisk;
        [SerializeField] private Ram ram;

        [SerializeField] private Process virtualProcess;
        [SerializeField] private Process physicalProcess;

        private readonly List<Process> _processes = new();

        public void CreateProcess(string text)
        {
            if (_processes.Any(t => t.Name == text))
                return;

            var process = Instantiate(virtualProcess, transform);
            process.Construct(text, true);
            _processes.Add(process);
            process.OnChanged += OnProcessChanged;
            process.OnPlayed += PlayProcess;
            PlayProcess(process);
        }

        private void PlayProcess(Process process)
        {
            if (ram.HasAny(process.Name))
                return;
            if (!ram.CanAdd())
            {
                var processFromRam = ram.GetNotRecentlyUsedProcess();
                hardDisk.AddProcess(processFromRam);
            }

            process.R = false;
            process.M = false;
            
            var physicalProcessNew = hardDisk.GrabProcess(process.Name);

            if (physicalProcessNew == null)
            {
                physicalProcessNew = Instantiate(physicalProcess);
                physicalProcessNew.Construct(process.Name, false);
            }

            physicalProcessNew.R = false;
            physicalProcessNew.M = false;
            ram.AddProcess(physicalProcessNew);
        }

        private void OnProcessChanged(Process process)
        {
            var processInMemory = ram.GetProcess(process.Name);
            if (processInMemory == null)
            {
                processInMemory = hardDisk.GetProcess(process.Name);
                if (processInMemory == null) throw new Exception("No process error");
            }

            processInMemory.R = process.R;
            processInMemory.M = process.M;
        }
    }
}
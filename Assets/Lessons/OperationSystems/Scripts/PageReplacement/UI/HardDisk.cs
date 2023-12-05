using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.PageReplacement.UI
{
    public class HardDisk : MonoBehaviour
    {
        private readonly List<Process> _processes = new List<Process>();

        public void AddProcess(Process processFromRam)
        {
            processFromRam.transform.SetParent(transform);
            processFromRam.R = false;
            processFromRam.M = false;
            _processes.Add(processFromRam);
        }

        public Process GrabProcess(string processName)
        {
            var process = GetProcess(processName);
            if (process == null)
                return null;
            
            _processes.Remove(process);
            return process;
        }

        public Process GetProcess(string processName)
        {
            return _processes.FirstOrDefault(t => t.Name == processName);
        }
    }
}
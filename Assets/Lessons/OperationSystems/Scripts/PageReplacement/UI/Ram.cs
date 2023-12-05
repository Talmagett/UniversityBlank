using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.PageReplacement.UI
{
    public class Ram : MonoBehaviour
    {
        [SerializeField] private int maxSize=4;
        private readonly List<Process> _processes = new List<Process>();
        
        public bool CanAdd() => _processes.Count < maxSize;
        
        public Process GetProcess(string processName) => 
            _processes.FirstOrDefault(t => t.Name == processName);

        public Process GetNotRecentlyUsedProcess()
        {
            var process = GetFirstRM(false,false);
            if (process == null)
            {
                process = GetFirstRM(false, true);
                if (process == null)
                {
                    process = GetFirstRM(true, false);
                    if (process == null)
                    {
                        process = GetFirstRM(true, true);
                        if (process == null)
                        {
                            process = _processes.FirstOrDefault()!;
                            process.R = false;
                        }
                    }
                }
            }

            _processes.Remove(process);
            return process;
        }

        private Process GetFirstRM(bool r,bool m)
        {
            var process = _processes.Where(t => t.R == r && t.M == m);
            return process.FirstOrDefault();
        }

        public void AddProcess(Process process)
        {
            process.transform.SetParent(transform);
            _processes.Add(process);
        }

        public bool HasAny(string processName)
        {
            return _processes.Any(t => t.Name == processName);
        }
    }
}
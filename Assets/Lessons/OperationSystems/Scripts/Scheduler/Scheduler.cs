using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.Scheduler
{
    public class Scheduler : MonoBehaviour
    {
        [SerializeField] private Process processPrefab;
        [SerializeField] private TMP_Text statistics;
        private readonly List<Process> _processes = new();

        public void CreateProcess(string processName, int executionTime, int arrivalTime)
        {
            var process = Instantiate(processPrefab, transform);
            process.Construct(processName, executionTime, arrivalTime);
            _processes.Add(process);
        }

        public void Schedule()
        {
            UpdateStats(_processes.ToArray(),true);
            var scheduled = _processes.OrderBy(t => t.ArrivalTime).ThenBy(t => t.ExecutionTime).ToArray();
            for (var i = 0; i < scheduled.Length; i++) scheduled[i].transform.SetSiblingIndex(i);
            UpdateStats(scheduled,false);
        }

        private void UpdateStats(Process[] scheduled,bool before)
        {
            float meanTurnaroundTime = 0;
            float averageWaitingTime = 0;
            for (var i = 0; i < scheduled.Length; i++)
            {
                meanTurnaroundTime += (scheduled[i].ExecutionTime * (scheduled.Length - i))-scheduled[i].ArrivalTime;
                if (i == 0)
                    continue;
                
                int processWaitTime = 0;
                for (int j = 0; j < i; j++)
                {
                    processWaitTime += scheduled[j].ExecutionTime;
                }
                averageWaitingTime += processWaitTime;
            }

            meanTurnaroundTime /= scheduled.Length;
            averageWaitingTime /= scheduled.Length;
            if (before)
                statistics.text = "";
            
            statistics.text += $"{(before?"Before":"After")}:\n Mean turnaround time={meanTurnaroundTime}\n" +
                              $"Average waiting time={averageWaitingTime}\n";
        }
    }
}
using TMPro;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.Scheduler
{
    public class Process : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text executionTimeText;
        [SerializeField] private TMP_Text arrivalTimeText;
        public string Name { get; private set; }
        public int ExecutionTime { get; private set; }
        public int ArrivalTime { get; private set; }

        public void Construct(string processName, int executionTime, int arrivalTime)
        {
            Name = processName;
            ExecutionTime = executionTime;
            ArrivalTime = arrivalTime;
            nameText.text = Name;
            executionTimeText.text = executionTime.ToString();
            arrivalTimeText.text = arrivalTime.ToString();
        }

/*
Scheduler algorithms
    1.	Shortest Job First
Menu
    3.	Generate schedule
    4.	Statistics (mean turnaround time, average waiting time)
*/
    }
}
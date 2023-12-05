using UnityEngine;

namespace Lessons.OperationSystems.Scripts.MemoryManagement
{
    public class Process
    {
        public string Name { get; private set; }
        public int RequiredSize { get; private set; }
        public int ProcessStartIndex { get; private set; }
        
        public Process(string name, int requiredSize, int processStartIndex)
        {
            Name = name;
            RequiredSize = requiredSize;
            ProcessStartIndex = processStartIndex;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons.OperationSystems.Scripts.MemoryManagement
{
    public class MemoryManager
    {
        public event Action<bool[]> OnMemoryChange;
        private readonly bool[] _memory;
        public List<Process> CurrentProcesses { get; } = new();

        public MemoryManager(int maxLength)
        {
            _memory = new bool[maxLength];
        }

        public void CreateProcess(string text, int length)
        {
            if (length <= 0)
                return;
            if (CurrentProcesses.Any(t => t.Name == text))
                return;
            
            var processStartIndex = FindFirstFit(length);
            if (processStartIndex == -1) 
                return;
            
            var process = new Process(text, length, processStartIndex);
            AddProcessToMemory(process);
            OnMemoryChange?.Invoke(_memory);
        }

        public void RemoveProcess(string text)
        {
            var process = CurrentProcesses.FirstOrDefault(t => t.Name == text);

            if (process == null)
                return;

            RemoveProcessFromMemory(process);
            OnMemoryChange?.Invoke(_memory);
        }

        private void AddProcessToMemory(Process process)
        {
            for (var j = 0; j < process.RequiredSize; j++)
            {
                _memory[process.ProcessStartIndex+j] = true;
            }
            CurrentProcesses.Add(process);
        }

        private void RemoveProcessFromMemory(Process process)
        {
            for (var i = 0; i < process.RequiredSize; i++)
            {
                _memory[i + process.ProcessStartIndex] = false;
            }
            CurrentProcesses.Remove(process);
        }

        private int FindFirstFit(int length)
        {
            var freeCounter = 0;
            for (var i = 0; i < _memory.Length; i++)
            {
                if (_memory[i])
                    freeCounter = 0;
                else
                    freeCounter++;

                if (freeCounter < length)
                    continue;
                
                return i - length+1;
            }

            return -1;
        }
    }
}
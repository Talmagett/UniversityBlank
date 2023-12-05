using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.OperationSystems.Scripts.MemoryManagement
{
    public class MemoryObserver:IDisposable
    {
        private MemoryManager _manager;
        private Image[] _images;
        private readonly TMP_Text _tmpText;

        public MemoryObserver(MemoryManager manager, Image[] images,TMP_Text tmpText)
        {
            _manager = manager;
            _images = images;
            _tmpText = tmpText;
            _manager.OnMemoryChange += UpdateVisual;
        }

        private void UpdateVisual(bool[] values)
        {
            if (_images.Length != values.Length)
                throw new Exception("memory disbalance");
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].color = values[i] ? Color.red : Color.white;
            }

            ShowCurrentProcesses();
        }

        private void ShowCurrentProcesses()
        {
            StringBuilder text = new StringBuilder();
            foreach (var process in _manager.CurrentProcesses)
            {
                text.Append($"{process.Name} - [{process.ProcessStartIndex}] size:{process.RequiredSize} \n");
            }

            _tmpText.text = text.ToString();
        }

        public void Dispose()
        {
            _manager.OnMemoryChange -= UpdateVisual;
        }
    }
}
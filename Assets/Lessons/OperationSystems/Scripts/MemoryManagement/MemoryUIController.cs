using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Lessons.OperationSystems.Scripts.MemoryManagement
{
    public class MemoryUIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField creatProcessNameIF;
        [SerializeField] private TMP_InputField createProcessLengthIF;
        [SerializeField] private TMP_InputField removeProcessNameInput;

        private MemoryManager _manager;
        

        public void Construct(MemoryManager memoryManager)
        {
            _manager = memoryManager;
        }

        public void CreateProcess()
        {
            if (creatProcessNameIF.text != "" && createProcessLengthIF.text != "")
            {
                var len = int.Parse(createProcessLengthIF.text);
                var processName = creatProcessNameIF.text;
                _manager.CreateProcess(processName,len);
            }
            creatProcessNameIF.text = "";
            createProcessLengthIF.text = "";   
        }

        public void RemoveProcess()
        {
            if (removeProcessNameInput.text != "")
            {
                var processName = removeProcessNameInput.text;
                _manager.RemoveProcess(processName);
            }

            removeProcessNameInput.text = "";
        }
    }
}
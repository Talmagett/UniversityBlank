using TMPro;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.PageReplacement.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField creatingInputField;
        [SerializeField] private VirtualMemory virtualMemory;
        
        public void CreateProcess()
        {
            if (creatingInputField.text != "")
            {
                virtualMemory.CreateProcess(creatingInputField.text);
            }
            creatingInputField.text = "";
        }
    }
}
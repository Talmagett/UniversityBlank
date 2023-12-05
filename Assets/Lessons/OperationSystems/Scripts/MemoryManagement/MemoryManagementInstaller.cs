using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.OperationSystems.Scripts.MemoryManagement
{
    public class MemoryManagementInstaller:MonoBehaviour
    {
        [SerializeField] private MemoryUIController memoryUIController;
        [SerializeField] private TMP_Text logsTMPText;
        [SerializeField] private Transform buttonsParent;
        private void Awake()
        {
            var manager = new MemoryManager(buttonsParent.childCount);
            var images= new List<Image>(buttonsParent.GetComponentsInChildren<Image>());
            images.Remove(buttonsParent.GetComponent<Image>());
            
            memoryUIController.Construct(manager);
            var memoryObserver = new MemoryObserver(manager,images.ToArray(),logsTMPText);
        }
    }
}
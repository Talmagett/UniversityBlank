using TMPro;
using UnityEngine;

namespace Lessons.OperationSystems.Scripts.Scheduler
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField processNameIf;
        [SerializeField] private TMP_InputField executionTimeIf;
        [SerializeField] private TMP_InputField arrivalTimeIf;

        [SerializeField] private Scheduler scheduler;

        public void CreateProcess()
        {
            if (processNameIf.text == "")
                return;
            if (executionTimeIf.text == "")
                return;
            if (arrivalTimeIf.text == "")
                return;

            var processName = processNameIf.text;
            var executionTime = int.Parse(executionTimeIf.text);
            var arrivalTime = int.Parse(arrivalTimeIf.text);
            if (executionTime <= 0 || arrivalTime < 0)
                return;
            scheduler.CreateProcess(processName, executionTime, arrivalTime);
            ClearInputFields();
        }

        public void Schedule()
        {
            scheduler.Schedule();
        }

        private void ClearInputFields()
        {
            processNameIf.text = "";
            executionTimeIf.text = "";
            arrivalTimeIf.text = "";
        }
    }
}
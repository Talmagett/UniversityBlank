using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.OperationSystems.Scripts.PageReplacement.UI
{
    public class Process : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button referenceBitButton;
        [SerializeField] private Button modifiedBitButton;
        [SerializeField] private TMP_Text processNameText;

        public event Action<Process> OnPlayed;
        public event Action<Process> OnChanged;
        private bool _r;
        private bool _m;
        public string Name { get; private set; }

        public bool R
        {
            get => _r;
            set
            {
                _r = value;
                _referenceBitImage.color = _r ? Color.red : Color.white;
            }
        }

        public bool M
        {
            get => _m;
            set
            {
                _m = value;
                _modifiedBitImage.color = _m ? Color.red : Color.white;
            }
        }

        private Image _referenceBitImage;
        private Image _modifiedBitImage;

        public void Construct(string processName, bool isVirtual)
        {
            _referenceBitImage = referenceBitButton.GetComponent<Image>();
            _modifiedBitImage = modifiedBitButton.GetComponent<Image>();
            Name = processName;

            processNameText.text = Name;

            referenceBitButton.onClick.AddListener(() =>
            {
                R = !R;
                OnChanged?.Invoke(this);
            });

            modifiedBitButton.onClick.AddListener(() =>
            {
                M = !M;
                if (M)
                    R = true;
                OnChanged?.Invoke(this);
            });

            playButton.onClick.AddListener(() => { OnPlayed?.Invoke(this); });

            R = false;
            M = false;

            playButton.enabled = isVirtual;
            if (isVirtual)
                Unlock();
            else
                Lock();
        }

        private void Lock()
        {
            referenceBitButton.interactable = false;
            modifiedBitButton.interactable = false;
        }

        private void Unlock()
        {
            referenceBitButton.interactable = true;
            modifiedBitButton.interactable = true;
        }
    }
}
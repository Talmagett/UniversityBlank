using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Otus.Scripts.UI
{
    public class EffectView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text valueText;

        public void SetIcon(Sprite icon)
        {
            this.icon.sprite = icon;
        }

        public void SetBackground(Color backgroundColor)
        {
            this.background.color = backgroundColor;
        }

        public void SetValue(float value)
        {
            valueText.text = value.ToString();
        }
    }
}
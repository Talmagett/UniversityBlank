using System;
using UnityEngine;

namespace Lessons.Otus.Scripts
{
    public class Effect
    {
        public event Action<float> OnValueChanged;
        public float Value { get; private set; }
        public Sprite Icon { get; }
        public Color Color { get; }
    
        public void SetValue(float value)
        {
            this.Value = value;
            this.OnValueChanged?.Invoke(this.Value);
        }
    
        public Effect(float value, Sprite icon, Color color)
        {
            this.Value = value;
            this.Icon = icon;
            this.Color = color;
        }
    }

}
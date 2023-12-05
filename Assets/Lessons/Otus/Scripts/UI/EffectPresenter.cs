using System;

namespace Lessons.Otus.Scripts.UI
{
    public class EffectPresenter : IDisposable
    {
        private EffectView _effectView;
        private Effect _effect;
        public EffectPresenter(EffectView effectView, Effect effect)
        {
            _effectView = effectView;
            _effect = effect;
            _effect.OnValueChanged += UpdateVisual;
        }

        public void Dispose()
        {
            _effect.OnValueChanged -= UpdateVisual;
        }
        
        private void UpdateVisual(float value)
        {
            _effectView.SetValue(value);
        }
    }
}
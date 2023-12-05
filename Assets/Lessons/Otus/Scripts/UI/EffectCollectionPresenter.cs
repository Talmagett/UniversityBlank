using System;
using Zenject;

namespace Lessons.Otus.Scripts.UI
{
    public class EffectCollectionPresenter : IInitializable,IDisposable
    {
        private EffectCollection _effectCollection;
        private EffectCollectionView _effectCollectionView;

        public EffectCollectionPresenter(EffectCollection effectCollection, EffectCollectionView effectCollectionView)
        {
            _effectCollection = effectCollection;
            _effectCollectionView = effectCollectionView;
        }

        public void Initialize()
        {
            _effectCollection.OnAdded += CreateEffect;
        }

        public void Dispose()
        {
            _effectCollection.OnAdded -= CreateEffect;
        }

        public void CreateEffect(Effect effect)
        {
            _effectCollectionView.CreateEffectView(effect.Icon,effect.Color,effect.Value);
        }
    }
}
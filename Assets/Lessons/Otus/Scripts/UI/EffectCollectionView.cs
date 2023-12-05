using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Otus.Scripts.UI
{
    public class EffectCollectionView : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private EffectView effectViewPrefab;

        private readonly List<EffectView> _createdEffects = new List<EffectView>();
        
        public void CreateEffectView(Sprite icon, Color color,float value)
        {
            var effectView = Instantiate(effectViewPrefab,parent);
            effectView.SetIcon(icon);
            effectView.SetBackground(color);
            effectView.SetValue(value);
            _createdEffects.Add(effectView);
        }

        public void RemoveEffect()
        {
            
        }
    }
}
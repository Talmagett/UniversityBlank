using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.Otus.Scripts
{
    public class EffectHelper:MonoBehaviour
    {
        [SerializeField] private EffectData[] effectDatas;
        private EffectCollection _effectCollection;
        
        [Inject]
        public void Construct(EffectCollection effectCollection)
        {
            _effectCollection = effectCollection;
        }

        [Button]
        public void AddEffect()
        {
            _effectCollection.AddEffect(new Effect(Random.Range(1,100),effectDatas[0].sprite,effectDatas[0].color));
        }
        
        [System.Serializable]
        public class EffectData
        {
            public Sprite sprite;
            public Color color;
        }
    }
}
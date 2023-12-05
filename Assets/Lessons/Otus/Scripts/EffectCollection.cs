using System;
using System.Collections.Generic;

namespace Lessons.Otus.Scripts
{
    public sealed class EffectCollection
    {
        public event Action<Effect> OnAdded;
        public event Action<Effect> OnRemoved;

        public int Count => this.effects.Count;

        private readonly HashSet<Effect> effects = new();

        public void AddEffect(Effect effect)
        {
            if (this.effects.Add(effect))
            {
                this.OnAdded?.Invoke(effect);
            }
        }

        public void RemoveEffect(Effect effect)
        {
            if (this.effects.Remove(effect))
            {
                this.OnRemoved?.Invoke(effect);
            }
        }

        public IEnumerable<Effect> GetEffects()
        {
            return this.effects;
        }
    }
}
using System.ComponentModel;
using Lessons.Otus.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Lessons.Otus.Scripts
{
    public class LevelInstaller:MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EffectCollectionPresenter>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EffectCollection>().AsSingle().NonLazy();
        }
    }
}
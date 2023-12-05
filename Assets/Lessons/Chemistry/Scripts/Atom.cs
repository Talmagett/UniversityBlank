using System;
using Lessons.Chemistry.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Lessons.Chemistry.Scripts
{
    public class Atom : MonoBehaviour
    {
        private readonly int[] _electronLayers = { 2,8,18,32,50,72,98};
        public event Action<AtomSO> OnInit;
        private AtomSO _atomSo;
        public void Construct(AtomSO atomSo)
        {
            _atomSo = atomSo;
            OnInit?.Invoke(atomSo);
        }
    }
}

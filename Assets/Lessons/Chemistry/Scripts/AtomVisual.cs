using System;
using Lessons.Chemistry.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Lessons.Chemistry.Scripts
{
    public class AtomVisual:MonoBehaviour
    {
        [SerializeField] private TMP_Text atomText;
        [SerializeField] private Atom atom;

        private void OnEnable()
        {
            atom.OnInit += InitVisual;
        }

        private void OnDisable()
        {
            atom.OnInit -= InitVisual;
        }

        private void InitVisual(AtomSO obj)
        {
            atomText.text = obj.name;
        }
    }
}
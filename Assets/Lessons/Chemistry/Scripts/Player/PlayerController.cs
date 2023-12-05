using System;
using UnityEngine;

namespace Lessons.Chemistry.Scripts.Player
{
    public class PlayerController:MonoBehaviour
    {
        private Atom _draggingAtom;
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                var hits = Physics2D.RaycastAll(Camera.main.transform.position, GetMousePosition());
                foreach (var hit in hits)
                {
                    if (hit.transform.TryGetComponent(out Atom atom))
                    {
                        _draggingAtom = atom;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                _draggingAtom = null;
            }

            if (_draggingAtom is not null)
            {
                _draggingAtom.transform.position=GetMousePosition();
            }
        }

        private Vector3 GetMousePosition()
        {
            var pos=  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            return pos;
        }
    }
}
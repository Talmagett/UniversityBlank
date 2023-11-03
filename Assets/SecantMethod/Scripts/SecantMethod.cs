using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace SecantMethod.Scripts
{
    public class SecantMethod : MonoBehaviour
    {
        [SerializeField] private Transform dot;
        [SerializeField] private float range;
        [SerializeField] private float x0;
        [SerializeField] private float x1;
        [SerializeField] private float tolerance =0.001f;
        [SerializeField] private int maxIterations;

        [SerializeField] private FunctionType functionType;
        private enum FunctionType
        {
            x,
            x2,
            x3,
            sinxx
        }

        [Space]
        [SerializeField] private LineRenderer liner;
        [SerializeField] private LineRenderer infLiner;
        [SerializeField] private TMP_Text dataText;
        [SerializeField] private Transform x0Transform;
        [SerializeField] private Transform x1Transform;
        private int _iterations;

        private float Function(float x)
        {
            switch (functionType)
            {
                case FunctionType.x:
                    return x-2;
                case FunctionType.x2:            
                    return x * x - 4;
                case FunctionType.x3:
                    return x * x * x+1;
                case FunctionType.sinxx:
                    return Mathf.Sin(x * 4) + x;
            }

            throw new Exception();
        }
        
        public void Start()
        {
            for (float x = -range; x <= range; x+=0.1f)
            {
                float y = Function(x);
                Instantiate(dot, new Vector2(x, y), Quaternion.identity);
            }
            liner.gameObject.SetActive(true);
            UpdateLines();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)&&maxIterations>0)
            {
                float x2 = x1 - (Function(x1) * (x1 - x0)) / (Function(x1) - Function(x0));
                if (Math.Abs(x2 - x1) < tolerance)
                {
                    x0 = x1;
                    x1 = x2;
                    UpdateLines();
                    
                    dataText.text = $"root is {x2}";

                    maxIterations = 0;
                    return;
                }
                x0 = x1;
                x1 = x2;

                if (float.IsInfinity(x1)||float.IsNaN(x1)||float.IsInfinity(x0)||float.IsNaN(x0))
                {
                    dataText.text = "No root";
                    maxIterations = -1;
                    return;
                }
                maxIterations--;
                UpdateLines();
            }
        }
        private void UpdateLines()
        {
            var firstPoint = new Vector2(x0, Function(x0));
            var secondPoint = new Vector2(x1, Function(x1));
            liner.SetPosition(0,firstPoint);
            liner.SetPosition(1,secondPoint);

            var dir = secondPoint - firstPoint;
            infLiner.SetPosition(0,firstPoint-dir.normalized*100);
            infLiner.SetPosition(1,secondPoint+dir.normalized*100);

            x0Transform.transform.position = firstPoint;
            x1Transform.transform.position = secondPoint;
            dataText.text = $"x0 = {x0} \n" +
                            $"x1 = {x1} \n";
        }
    }
}

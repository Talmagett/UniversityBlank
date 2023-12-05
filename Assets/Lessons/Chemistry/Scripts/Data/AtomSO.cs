using UnityEngine;
using UnityEngine.Serialization;

namespace Lessons.Chemistry.Scripts.Data
{
    [CreateAssetMenu(menuName = "SO/Chemistry/ElementSO",fileName = "ElementSO",order = 0)]
    public class AtomSO : ScriptableObject
    {
        public int Id;
        public int[] Valencies = new int[]{};
    }
}

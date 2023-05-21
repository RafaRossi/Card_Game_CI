using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Element")]
    public class Element : ScriptableObject
    {
        [SerializeField] private List<Element> weakness = new List<Element>();
        [SerializeField] private List<Element> strongness = new List<Element>();

        public List<Element> GetWeakness() => weakness;
        public List<Element> GetStrongness() => strongness;

        public Color elementColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Ability : ScriptableObject
    {
        [field:SerializeField] public string AbilityName;
        [field:SerializeField] [TextArea] public string AbilityDescription;
        [field:SerializeField] public Element AbilityElement { get; set; }
        [field:SerializeField] public float ManaCost = 0;
        public List<BaseAbilityBehaviour> AbilityBehaviours = new List<BaseAbilityBehaviour>();
    }
}

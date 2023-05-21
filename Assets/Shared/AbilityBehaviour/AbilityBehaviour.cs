using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class BaseAbilityBehaviour : MonoBehaviour
    {
        
    }
    
    public abstract class AbilityBehaviour<T>: BaseAbilityBehaviour where T : Ability
    {
        protected T _ability;
        
        public void InitializeAbility(T ability)
        {
            _ability = ability;
        }
    }

    public interface IAbilityType
    {
        
    }

    public interface IPassiveAbility : IAbilityType
    {
        void ActivateEffect();
    }

    public interface IActiveAbility<in T> : IAbilityType
    {
        void UseAbility(T abilityTarget);
    }
}


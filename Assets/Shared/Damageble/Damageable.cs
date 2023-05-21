using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
    }

    public class Damageable : MonoBehaviour, IDamageable
    {
        private Health _health;
    
        public void TakeDamage(float damage)
        {
            _health.AddValue(-damage);
        }
    }
}


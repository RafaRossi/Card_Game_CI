using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class BaseValueClass
    {
        private float _value;
        
        public static Action OnBaseValueUpdated = delegate {  };

        public float Value
        {
            get => _value;
            protected set
            {
                _value = Mathf.Clamp(value, 0, _maxValue);
                
                OnBaseValueUpdated?.Invoke();
            }
        }

        protected float _maxValue;

        protected BaseValueClass(float initialValue, float maxValue)
        {
            _value = initialValue;
            _maxValue = maxValue;
        }

        public virtual void AddValue(float value)
        {
            Value += value;
        }

        public virtual void SetValue(float value)
        {
            Value = value;
        }

        public virtual void ChangeMaxValue(float newValue)
        {
            _maxValue = newValue;
        }
    }

    [Serializable]
    public class Health : BaseValueClass
    {
        public Action OnDie = delegate {  };

        public override void AddValue(float value)
        {
            base.AddValue(value);

            if (!(Value <= 0)) return;
        
            Value = 0;
            
            OnDie?.Invoke();
        }

        public Health(float initialValue, float maxValue) : base(initialValue, maxValue)
        {
        }
    }
}

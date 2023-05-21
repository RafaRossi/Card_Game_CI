using System;
using UnityEngine;

namespace Game
{
    public enum TargetType
    {
        Self,
        Ally,
        Enemy
    }

    [Serializable]
    public class Target
    {
        [field:SerializeField] public Color TargetColor { get; set; }
        [field:SerializeField] public TargetType TargetType { get; set; }
    }

    [Serializable]
    public abstract class TargetEffect
    {
        [field:SerializeField] public Target Target { get; set; }
        [field:SerializeField] public Effect Effect { get; set; }
    }

    [Serializable]
    public class DamageEffect : TargetEffect
    {
        [SerializeField] private float baseAttackPower;
        [SerializeField] private float baseManaCost;

        public float GetBaseAttackPower() => baseAttackPower;
        public float GetBaseManaCost() => baseManaCost;
    }
}
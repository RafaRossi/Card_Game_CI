using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

[CreateAssetMenu(menuName = "Heal Ability")]
public class HealAbility : Ability
{
    [field:SerializeField] public float HealAmount { get; }
}

using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

[CreateAssetMenu(menuName = "Damage Ability")]
public class DamageAbility : Ability
{
    [field:SerializeField] public float DamagePower { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class SingleDamageAbility : AbilityBehaviour<DamageAbility>, IActiveAbility<IDamageable>
{
    public void UseAbility(IDamageable abilityTarget)
    {
        abilityTarget.TakeDamage(_ability.DamagePower);
    }
}

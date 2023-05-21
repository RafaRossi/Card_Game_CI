using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class SingleHealBehaviour : AbilityBehaviour<HealAbility>, IActiveAbility<Health>
{
    public void UseAbility(Health abilityTarget)
    {
        abilityTarget.AddValue(_ability.HealAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardAbilityButton : MonoBehaviour
{
    [SerializeField] private TMP_Text abilityNameText;
    [SerializeField] private TMP_Text abilityDescription;

    [SerializeField] private Image buttonBackground;
    
    public void Initialize(Ability ability)
    {
        abilityNameText.text = ability.AbilityName;
        abilityDescription.text = ability.AbilityDescription;

        buttonBackground.color = ability.AbilityElement.elementColor;
        
        gameObject.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text cardNameText;
    
    [FormerlySerializedAs("card")] [SerializeField] private Card cardProperties;
    
    private void OnEnable()
    {
        BaseValueClass.OnBaseValueUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        BaseValueClass.OnBaseValueUpdated -= UpdateUI;
    }
    
    private void UpdateUI()
    {
        healthText.text = cardProperties.Health.Value.ToString(CultureInfo.CurrentCulture);
        cardNameText.text = cardProperties.GetCardName();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;

public class CardImage : MonoBehaviour, ICardProperties
{
    [SerializeField] private RawImage rawImage;
    private void Awake()
    {
        InitializeCard();
    }

    private void InitializeCard()
    {
        rawImage.material = Instantiate(rawImage.material);
        CardMaterial.InitializeCardMaterial(rawImage.material, CardAsset);
    }

    public CardMaterial CardMaterial { get; set; }
    [field:SerializeField] public CardAsset CardAsset { get; set; }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
    }
}

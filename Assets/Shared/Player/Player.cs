using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Player
{
    public PlayerData playerData;
    [field:SerializeField] public Mana Mana {  get; set; }

    public List<CardAsset> CardAssets = new List<CardAsset>();
}

[Serializable]
public class PlayerData
{
    public string PlayerID;
    public string PlayerName;
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurnManager : Managers
{
    public Action OnChangeTurn = delegate {  };
    public Turn CurrentTurn { get; private set; }

    public void ChangeTurn(Turn newTurn)
    {
        CurrentTurn = newTurn;
        
        OnChangeTurn?.Invoke();
    }

    public override void Initialize()
    {
        
    }
}

public class Turn
{
    public Player CurrentPlayer;
    public int TurnNumber = 1;
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchManager : Managers
{
    public static Action OnMatchStart = delegate {  };
    public static Action OnMatchEnd = delegate {  };

    public Player[] players = new Player[2];

    [SerializeField] private TurnManager _turnManager;

    private void OnEnable()
    {
        OnMatchStart += StartMatch;
    }

    private void OnDisable()
    {
        OnMatchStart -= StartMatch;
    }

    private void StartMatch()
    {
        _turnManager.ChangeTurn(new Turn { CurrentPlayer = players[0], TurnNumber = 1});
    }

    public override void Initialize()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class GameManager : Managers
{
    [SerializeField] private float delayTime;
    [SerializeField] private List<Managers> managers = new List<Managers>();

    public static Action<Card> OnCardSelected = delegate(Card card) {  };

    private IEnumerator Start()
    {
        Initialize();
        
        yield return new WaitForSeconds(delayTime);
        
        MatchManager.OnMatchStart?.Invoke();
    }


    public override void Initialize()
    {
        foreach (var manager in managers)
        {
            manager.Initialize();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TileableComponent : MonoBehaviour, ITilable
{
    public void PutOnTile(Action OnPutOnTile)
    {
        OnPutOnTile?.Invoke();
    }
}


public interface ITilable
{
    void PutOnTile(Action OnPutOnTile);
}

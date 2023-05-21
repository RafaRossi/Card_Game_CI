using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GridTilePosition _position;

    public bool IsOccupied { get; private set; }

    private ITilable _tilable;

    public Tile Initialize(GridRow row, GridColumn column)
    {
        row.tiles.Add(this);
        column.tiles.Add(this);
        
        _position = new GridTilePosition(row, column);

        return this;
    }

    public void PutOnTile(ITilable tileable)
    {
        _tilable = tileable;

        IsOccupied = true;
        
        _tilable.PutOnTile(null);
    }
}

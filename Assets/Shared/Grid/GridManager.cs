using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : Managers
{
    private List<Tile> Tiles = new List<Tile>();

    private int rowNumbers = 2;
    private int columnNumbers = 6;

    [SerializeField] private GridArea[] gridAreas = new GridArea[2];
    
    public void CreateTiles()
    {
        foreach (var gridArea in gridAreas)
        {
            var tileIndex = 0;
            
            var rows = new GridRow[rowNumbers];
            var columns = new GridColumn[columnNumbers];

            for (var i = 0; i < rows.Length; i++)
            {
                rows[i] = new GridRow { gridElementID = i };
            }

            for (var i = 0; i < columns.Length; i++)
            {
                columns[i] = new GridColumn { gridElementID = i };
            }

            foreach (var row in rows)
            {
                for (var j = 0; j < columns.Length; j++, tileIndex++)
                {
                    Tiles.Add(gridArea.Tiles[tileIndex].Initialize(row, columns[j]));
                    //Tiles.Add(Instantiate(tilePrefab, gridParent).Initialize(i, j));
                }
            }
        }
    }

    public override void Initialize()
    {
        CreateTiles();
    }
}

[Serializable]
public abstract class GridElement
{
    public int gridElementID = 0;
    public List<Tile> tiles = new List<Tile>();
}

[Serializable]
public class GridTilePosition
{
    public GridRow row;
    public GridColumn column;

    public GridTilePosition(GridRow row, GridColumn column)
    {
        this.row = row;
        this.column = column;
    }
}

[Serializable]
public class GridArea
{
    public Team GridTeam;

    private List<GridRow> rows = new List<GridRow>();
    private List<GridColumn> columns = new List<GridColumn>();

    public List<Tile> Tiles = new List<Tile>();
    
    public GridArea(Team gridTeam)
    {
        GridTeam = gridTeam;
    }
}

[Serializable]
public class GridRow : GridElement
{
    
}

[Serializable]
public class GridColumn : GridElement
{
    
}
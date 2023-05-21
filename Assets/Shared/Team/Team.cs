using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public Player TeamPlayer;
    public TeamColor TeamColor { get; }

    public Team(Player teamName, TeamColor teamColor)
    {
        TeamPlayer = teamName;
        TeamColor = teamColor;
    }
}

public class TeamColor
{
    public Color Color { get; }
    
    public TeamColor(Color color)
    {
        Color = color;
    }
}

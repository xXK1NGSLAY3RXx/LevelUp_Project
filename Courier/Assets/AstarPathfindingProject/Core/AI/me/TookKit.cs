using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TookKit
{
    public static Vector2 DirectionToVector(Direction dir)
    {
        switch (dir)
        {
            case Direction.left: return Vector2.left;
            case Direction.up: return Vector2.up;
            case Direction.down: return Vector2.down;
            case Direction.right: return Vector2.right;
            default: return Vector2.zero;
        }
        
    }

    public static Direction VectorToDirection(Vector2 vec)
    {
        if (vec == Vector2.right)
            return Direction.right;
        else if (vec == Vector2.up)
            return Direction.up;
        else if (vec == Vector2.left)
            return Direction.left;
        else if (vec == Vector2.down)
            return Direction.down;
        else return Direction.empty;
    }
}

public enum Direction
{
   empty, left, down, up, right
}
public enum collectables
{
    coin,powerup
}

public enum TileID
{
    block = 1,coin = 2
    


} 

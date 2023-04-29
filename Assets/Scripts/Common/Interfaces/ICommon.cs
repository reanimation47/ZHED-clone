using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommon 
{
    //grid manager
    private static GridManager grid_manager;
    private static Dictionary<Vector2, Tile> tiles;

    public static void LoadGridManager(GridManager GridManager)
    {
        grid_manager = GridManager;
        tiles = grid_manager.tiles;
    }

    public static GridManager GetGridManager()
    {
        return grid_manager;
    }


    //common methods
    public static Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var _tile))
        {
            return _tile;
        }

        return null;
    }

}

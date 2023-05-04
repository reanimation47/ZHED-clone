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

    //Controlling nodes on preview state
    private static Tile onpreview_tile;
    public static void RegisterPreviewNode(Tile _tile)
    {
        if (onpreview_tile) //if another tile is already registered
        {
            ReleasePreviewNode(); // release it
        } 
        onpreview_tile = _tile; //register new tile
    }

    public static Tile GetRegisteredPreviewNode()
    {
        return onpreview_tile;
    }

    public static void ReleasePreviewNode()
    {
        grid_manager.ToggleNodePreviews(onpreview_tile);
        onpreview_tile = null;
    }

    public static void ReleasePreviewNodeRaw() //only releasing the variable
    {
        onpreview_tile = null;
    }


}

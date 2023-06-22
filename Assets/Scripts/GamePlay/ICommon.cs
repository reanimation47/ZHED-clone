using System.Collections;
using System.Collections.Generic;
using GamePlay.Grid;
using UnityEngine;
using GamePlay.Tiles;

namespace GamePlay
{
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
        private static Tile onpreview_node;
        public static void RegisterPreviewNode(Tile _tile)
        {
            if (onpreview_node) //if another tile is already registered
            {
                ReleasePreviewNode(); // release it
            }
            onpreview_node = _tile; //register new tile
        }

        public static Tile GetRegisteredPreviewNode()
        {
            return onpreview_node;
        }

        public static void ReleasePreviewNode()
        {
            grid_manager.ToggleNodePreviews(onpreview_node);
            onpreview_node = null;
        }

        public static void ReleasePreviewNodeRaw() //only releasing the variable
        {
            onpreview_node = null;
        }

        //Controlling tiles on preview state
        private static List<Tile> tiles_onpreview = new List<Tile>();

        public static void RegisterNewPreviewTile(Tile _tile)
        {
            tiles_onpreview.Add(_tile);
        }

        public static void ReleaseAllPreviewTiles()
        {
            foreach (Tile _tile in tiles_onpreview)
            {
                _tile.SetPreviewState(0);
            }
            tiles_onpreview.Clear();
        }


    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Tiles;

namespace GamePlay.Grid
{
    public class GridManager : GridExtension
    {

        [SerializeField] private int grid_w, grid_h;
        [SerializeField] private Tile tile;
        [SerializeField] private Transform camera_transform;

        //anim values
        [SerializeField] private float preview_anim_delay = 0.05f;

        public List<Vector3Int> node_values;
        //[HideInInspector]public List<Vector2> node_positions;
        //[HideInInspector]public List<int> node_numbers;

        public Vector2Int goal_node_position;

        public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
        public Dictionary<Vector2, int> nodes = new Dictionary<Vector2, int>(); // special tiles

        private void Start()
        {
            ICommon.LoadGridManager(this);
            GenerateGrid();
            addNodes();
            GenerateNodes();
        }

        //custom methods

        private void GenerateGrid()
        {
            camera_transform.position = new Vector3((float)grid_w / 2 - 0.5f, (float)grid_h / 2 - 0.5f, -10);

            for (int x = 0; x < grid_w; x++)
            {
                for (int y = 0; y < grid_h; y++)
                {
                    var spanwedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                    spanwedTile.name = $"Tile{x}{y}";

                    var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                    spanwedTile.Init(isOffset);

                    tiles[new Vector2(x, y)] = spanwedTile;
                }
            }
        }


        private void addNodes()
        {

            for (int i = 0; i < node_values.Count; i++)
            {
                //node_positions.Add(new Vector2(node_values[i].x, node_values[i].y));
                //node_numbers.Add(node_values[i].z);

                var _node_pos = new Vector2(node_values[i].x, node_values[i].y);
                var _node_value = node_values[i].z;

                nodes.Add(_node_pos, _node_value);
            }

        }

        private void GenerateNodes()
        {
            foreach (KeyValuePair<Vector2, int> node in nodes)
            {
                //node.Key, node.Value
                Tile _target_tile = ICommon.GetTileAtPosition(node.Key);
                if (_target_tile)
                {
                    _target_tile.InitNode(node.Value);
                }
                else //invalid node
                {
                    Debug.LogError("Provided position is out of range. Cannot generate invalid node at: " + (node.Key).ToString());
                }
            }

            Tile _goal_node = ICommon.GetTileAtPosition(goal_node_position);
            _goal_node.InitGoalNode();

        }

        //custom public methods
        public void ToggleNodePreviews(Tile target_node)
        {
            if (target_node.IsAnExpandedThroughNode())
            {
                target_node.ForceSetDefaultPreviewMode();
            }

            if ((int)target_node.preview_state == 0)
            {
                ICommon.RegisterPreviewNode(target_node);
                StartCoroutine(CreatePreviews(target_node, preview_anim_delay));
            }
            else if ((int)target_node.preview_state == 1)
            {
                StartCoroutine(RemovePreviews(target_node, preview_anim_delay));
                ICommon.ReleasePreviewNodeRaw();
            }
        }

    }

}



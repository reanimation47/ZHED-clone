using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int grid_w, grid_h;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform camera_transform;

    public List<Vector3> node_values;
    public List<Vector2> node_positions;
    public List<float> node_numbers;

    public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
    public Dictionary<Vector2, float> nodes = new Dictionary<Vector2, float>(); // special tiles

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
            node_positions.Add(new Vector2(node_values[i].x, node_values[i].y));
            node_numbers.Add(node_values[i].z);

            nodes.Add(node_positions[i], node_numbers[i]);
        }


    }

    private void GenerateNodes()
    {
        foreach (KeyValuePair<Vector2, float> node in nodes)
        {

            //node.Key, node.Value
            Tile target_tile = ICommon.GetTileAtPosition(node.Key);
            target_tile.InitNode(node.Value);

        }

    }



    
}

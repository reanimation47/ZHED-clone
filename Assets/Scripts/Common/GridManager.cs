using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int grid_w, grid_h;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform camera_transform;

    private void Start()
    {
        GenerateGrid();
    }

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
            }
        }
    }
    
}

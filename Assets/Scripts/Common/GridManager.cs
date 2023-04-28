using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int grid_w, grid_h;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform camera_transform;

    private Dictionary<Vector2, Tile> tiles;

    private void Start()
    {
        ICommon.LoadGridManager(this);
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        camera_transform.position = new Vector3((float)grid_w / 2 - 0.5f, (float)grid_h / 2 - 0.5f, -10);

        tiles = new Dictionary<Vector2, Tile>();
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

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var _tile))
        {
            return _tile;
        }

        return null;
    }

    
}

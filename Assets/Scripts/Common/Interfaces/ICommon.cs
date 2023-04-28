using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommon 
{
    public static GridManager grid_manager;

    public static void LoadGridManager(GridManager GridManager)
    {
        grid_manager = GridManager;
    }

    public static GridManager GetGridManager()
    {
        return grid_manager;
    }
}

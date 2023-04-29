using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color base_color, offset_color, node_color;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject overlay;

    //states
    public enum tile_state { idle, onhover }
    public tile_state state;

    private GridManager GridManager;

    //Unity events
    private void Start()
    {
        GridManager = ICommon.GetGridManager();
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? offset_color : base_color;
    }

    public void InitNode()
    {
        _renderer.color = node_color;
    }

    private void OnMouseEnter()
    {
        state = tile_state.onhover;
        update_tile_state(state);
    }

    private void OnMouseExit()
    {
        state = tile_state.idle;
        update_tile_state(state);
    }

    private void OnMouseDown()
    {
        
    }

    //custom methods
    public void update_tile_state(tile_state current_state)
    {
        bool enable_overlay = state == tile_state.onhover ? true : false;
        overlay.SetActive(enable_overlay);
    }
}

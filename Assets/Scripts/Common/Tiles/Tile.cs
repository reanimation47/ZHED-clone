using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color base_color, offset_color, node_color;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject node_preview;



    public GameObject node_number;
    private TextMeshPro node_number_text;
    private TileExtension Extension = new TileExtension();

    //Dictionaries
    public Dictionary<preview_states, float> preview_state_to_scale = new Dictionary<preview_states, float>()
    {
        {preview_states.disabled, 0f },
        {preview_states.showpreview, 0.3f },
        {preview_states.expanded, 1f }
    };


    //values
    public int node_value = 0;
    public bool is_a_node = false;

    //states
    public enum tile_state { idle, onhover }
    public tile_state state;

    //preview states
    public enum preview_states { disabled, showpreview, expanded }
    public preview_states preview_state;

    //specials
    Vector2 node_preview_scaler = new Vector2 (1,1);

    private GridManager GridManager;

    //Unity events
    private void Start()
    {
        GridManager = ICommon.GetGridManager();
        
    }

    private void Update()
    {
        node_preview.transform.localScale = node_preview_scaler;
    }

    private void FixedUpdate()
    {
        switch(preview_state)
        {
            case preview_states.disabled:
                float _target = GetTargetPreviewScaleValue(preview_state);
                break;
            case preview_states.showpreview:
                break;
            case preview_states.expanded:
                break;
            default:
                break;
        }
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
        GeneratePreviews();
    }

    //custom methods

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? offset_color : base_color;
    }

    public void InitNode(int _value)
    {
        is_a_node = true;
        node_value = _value;

        _renderer.color = node_color;
        Extension.SetTileValue(this);

    }

    public void update_tile_state(tile_state current_state)
    {
        bool enable_overlay = state == tile_state.onhover ? true : false;
        overlay.SetActive(enable_overlay);
    }

    private void GeneratePreviews()
    {
        if (!is_a_node) { return; } //Do nothing is this tile is not a node
        GridManager.GenerateNodePreviews(this);
    }

    private float GetTargetPreviewScaleValue(preview_states state)
    {
        if (preview_state_to_scale.ContainsKey(state))
        {
            return preview_state_to_scale[state];
        }
        else
        {
            return preview_state_to_scale[preview_states.disabled];
        }
    }

}

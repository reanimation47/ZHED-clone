using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tile : TileExtension
{
    [SerializeField] private Color base_color, offset_color, node_color;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject overlay;
    [SerializeField] private GameObject node_preview;



    public GameObject node_number;
    private TextMeshPro node_number_text;
    //private TileExtension Extension = new TileExtension();

    //Dictionaries
    


    //values
    public int node_value = 0;
    public bool is_a_node = false;
    public bool node_expanded = false;

    //states
    public enum tile_state { idle, onhover }
    public tile_state state;

    

    //specials
    Vector2 node_preview_scaler = new Vector2 (0,0);

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
        
        float _target = GetTargetPreviewScaleValue(preview_state);
        if (is_a_node) { _target = 0; } //Not showing preview state for nodes
        node_preview_scaler.x = Mathf.Lerp(node_preview_scaler.x, _target, 0.2f);
        node_preview_scaler.y = Mathf.Lerp(node_preview_scaler.y, _target, 0.2f);
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
        if (node_expanded) { return; } //once expanded, this node is longer clickable
        GeneratePreviews();
        ExpandPreview();
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
        SetTileValue(this);

    }

    public void SetPreviewState(int _state)
    {
        if (preview_state == preview_states.expanded)
        {
            return;
        }
        switch (_state)
        {
            case 0:
                preview_state = preview_states.disabled;
                break;
            case 1:
                preview_state = preview_states.showpreview;
                break;
            case 2:
                preview_state = preview_states.expanded;
                break;
            default: //fallback
                Debug.LogError("preview state index not in expected range.");
                preview_state = preview_states.disabled;
                break;
        }
    }

    public void update_tile_state(tile_state current_state)
    {
        bool enable_overlay = state == tile_state.onhover ? true : false;
        overlay.SetActive(enable_overlay);
    }

    private void GeneratePreviews()
    {
        if (!is_a_node) { return; } //Do nothing is this tile is not a node
        GridManager.ToggleNodePreviews(this);
    }

    private void ExpandPreview()
    {
        if (preview_state != preview_states.showpreview || is_a_node)
        {
            return; //Do nothing if this tile is not in preview mode OR its a node
        }
        node_expanded = true;
        StartExpanding();
    }

    public void NodeExpanded()
    {
        node_expanded = true;
    }

    public bool isExpandedOrIsANode()
    {
        return preview_state == preview_states.expanded || is_a_node;
    }
}

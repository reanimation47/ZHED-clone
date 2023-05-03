using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using static TileExtension;

public class TileExtension : MonoBehaviour
{
    
    public TileExtension() { }
    //preview states
    public enum preview_states { disabled, showpreview, expanded }
    //preview states
    public preview_states preview_state;

    public Dictionary<preview_states, float> preview_state_to_scale = new Dictionary<preview_states, float>()
    {
        {preview_states.disabled, 0f },
        {preview_states.showpreview, 0.5f },
        {preview_states.expanded, 1f }
    };

    public void SetTileValue(Tile tile)
    {
        //Debug.Log(_value);
        TextMeshPro _value_text = tile.node_number.GetComponent<TextMeshPro>();
        _value_text.text = tile.node_value.ToString();
    }

    public float GetTargetPreviewScaleValue(preview_states state)
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

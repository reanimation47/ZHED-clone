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

    public void StartExpanding()
    {
        StartCoroutine(CoStartExpanding());
        ICommon.ReleasePreviewNode();
    }

    private IEnumerator CoStartExpanding()
    {

        //ICommon.ReleasePreviewNode();
        Tile _root_node = ICommon.GetRegisteredPreviewNode(); //Getting the root node
        _root_node.NodeExpanded();

        Vector3 pos_diff = transform.position - _root_node.transform.position;
        Vector3 pos_diff_direction = pos_diff.normalized;
        int pos_distance = (int)Vector3.Distance(transform.position, _root_node.transform.position);

        for (int i = 1; i <= pos_distance; i++)
        {
            Vector3 _tile_pos = _root_node.transform.position + pos_diff_direction * i;
            Tile _tile = ICommon.GetTileAtPosition(_tile_pos);
            _tile.SetPreviewState(2);
            yield return new WaitForSeconds(0.1f);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridExtension : MonoBehaviour
{
    int extra_above_expansion = 0;
    int extra_below_expansion = 0;
    int extra_right_expansion = 0;
    int extra_left_expansion = 0;

    public IEnumerator CreatePreviews(Tile _target_node, float _anim_delay)
    {
        int _target_state = 1;

        _target_node.SetPreviewState(_target_state);
        Vector2 _node_pos = _target_node.transform.position;
        int _node_value = _target_node.node_value;

       
        for (int i = 1; i <= _node_value; i++)
        {
            //above tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.up * i;
                CreatePreview(_target_state, _node_pos, _preview_pos, _node_value, Vector2.up);
            }

            //below tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.down * i;
                CreatePreview(_target_state, _node_pos, _preview_pos, _node_value, Vector2.down);
            }

            //on the right tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.right * i;
                CreatePreview(_target_state, _node_pos, _preview_pos, _node_value, Vector2.right);
            }

            //on the left tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.left * i;
                CreatePreview(_target_state, _node_pos, _preview_pos, _node_value, Vector2.left);
            }

            yield return new WaitForSeconds(_anim_delay);
        }
    }

    public IEnumerator RemovePreviews(Tile _target_node, float _anim_delay)
    {
        int _target_state = 0;
        _target_node.SetPreviewState(_target_state);

        ICommon.ReleaseAllPreviewTiles();
        yield return new WaitForSeconds(0);

        extra_above_expansion = 0;
        extra_below_expansion = 0;
        extra_right_expansion = 0;
        extra_left_expansion = 0;
    }

    private void CreatePreview(int _target_state, Vector2 _node_pos, Vector3 _preview_pos, int _node_value, Vector2 _direction)
    {
        //int _target_state = 1;

        Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
        if (_preview_tile) //If such tile exists
        {
            ICommon.RegisterNewPreviewTile(_preview_tile);
            if (_preview_tile.isExpanded())
            {
                if (_direction == Vector2.up)
                {
                    CreateExtraPreviews(_target_state, _node_pos, _node_value, _direction, ref extra_above_expansion);
                }
                else if (_direction == Vector2.down)
                {
                    CreateExtraPreviews(_target_state, _node_pos, _node_value, _direction, ref extra_below_expansion);
                }
                else if (_direction == Vector2.right)
                {
                    CreateExtraPreviews(_target_state, _node_pos, _node_value, _direction, ref extra_right_expansion);
                }
                else if (_direction == Vector2.left)
                {
                    CreateExtraPreviews(_target_state, _node_pos, _node_value, _direction, ref extra_left_expansion);
                }



            }
            _preview_tile.SetPreviewState(_target_state);
        }
    }

    private void CreateExtraPreviews(int _target_state, Vector2 _node_pos, int _node_value, Vector2 _direction, ref int _extra_var_ref)
    {
        _extra_var_ref = _target_state == 1 ? _extra_var_ref + 1 : _extra_var_ref;
        Vector3 _extra_pos = _node_pos + _direction * (_node_value + _extra_var_ref);
        Tile _extra_tile = ICommon.GetTileAtPosition(_extra_pos);

        if (!_extra_tile) { return; } // abort if no such tile exists
        ICommon.RegisterNewPreviewTile(_extra_tile);
        _extra_tile.SetPreviewState(_target_state);

        if (_extra_tile.isExpanded())
        {
            CreateExtraPreviews(_target_state, _node_pos, _node_value, _direction, ref _extra_var_ref);
        }
    }

    

    
}

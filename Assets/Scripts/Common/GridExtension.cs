using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridExtension : MonoBehaviour
{
    int extra_above_expansion = 0;
    int extra_below_expansion = 0;
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
                CreatePreview(_node_pos, _preview_pos, _node_value, Vector2.up);
            }

            //below tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.down * i;
                CreatePreview(_node_pos, _preview_pos, _node_value, Vector2.down);
            }

            //on the right tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.right * i;
                CreatePreview(_node_pos, _preview_pos, _node_value, Vector2.right);
            }

            //on the left tiles
            {
                Vector3 _preview_pos = _node_pos + Vector2.left * i;
                CreatePreview(_node_pos, _preview_pos, _node_value, Vector2.left);
            }

            yield return new WaitForSeconds(_anim_delay);
        }
    }

    public IEnumerator RemovePreviews(Tile _target_node, float _anim_delay)
    {
        int _target_state = 0;

        _target_node.SetPreviewState(_target_state);
        Vector2 _node_pos = _target_node.transform.position;
        int _node_value = _target_node.node_value;

        for (int i = 1; i <= _node_value; i++)
        {
            //above tiles
            {
                Vector3 _preview_pos = _node_pos + new Vector2(0, i);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    if (_preview_tile.isExpanded())
                    {
                        //extra_above_expansion += 1;

                        Vector3 _extra_pos = _node_pos + Vector2.up * (_node_value + extra_above_expansion);
                        Tile _extra_tile = ICommon.GetTileAtPosition(_extra_pos);

                        _extra_tile.SetPreviewState(_target_state);

                    }
                    _preview_tile.SetPreviewState(_target_state);
                }
            }

            //below tiles
            {
                Vector3 _preview_pos = _node_pos - new Vector2(0, i);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(_target_state);
                }
            }

            //on the right tiles
            {
                Vector3 _preview_pos = _node_pos + new Vector2(i, 0);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(_target_state);
                }
            }

            //on the left tiles
            {
                Vector3 _preview_pos = _node_pos - new Vector2(i, 0);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(_target_state);
                }
            }

            yield return new WaitForSeconds(_anim_delay/10);
        }

        extra_above_expansion = 0;
    }

    private void CreatePreview(Vector2 _node_pos, Vector3 _preview_pos, int _node_value, Vector2 _direction)
    {
        int _target_state = 1;

        Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
        if (_preview_tile) //If such tile exists
        {
            if (_preview_tile.isExpanded())
            {
                if (_direction == Vector2.up)
                extra_above_expansion += 1;

                Vector3 _extra_pos = _node_pos + Vector2.up * (_node_value + extra_above_expansion);
                Tile _extra_tile = ICommon.GetTileAtPosition(_extra_pos);

                _extra_tile.SetPreviewState(_target_state);

            }
            _preview_tile.SetPreviewState(_target_state);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridExtension : MonoBehaviour
{
    public IEnumerator CreatePreviews(Tile _target_node, float _anim_delay)
    {
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
                    _preview_tile.SetPreviewState(1);
                }
            }

            //below tiles
            {
                Vector3 _preview_pos = _node_pos - new Vector2(0, i);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(1);
                }
            }

            //on the right tiles
            {
                Vector3 _preview_pos = _node_pos + new Vector2(i, 0);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if (_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(1);
                }
            }

            //on the left tiles
            {
                Vector3 _preview_pos = _node_pos - new Vector2(i, 0);
                Tile _preview_tile = ICommon.GetTileAtPosition(_preview_pos);
                if(_preview_tile) //If such tile exists
                {
                    _preview_tile.SetPreviewState(1);
                }
            }

            yield return new WaitForSeconds(_anim_delay);
        }
    }
}

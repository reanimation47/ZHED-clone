using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color base_color, offset_color;
    [SerializeField] private SpriteRenderer _renderer;

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? offset_color : base_color;
    }
}

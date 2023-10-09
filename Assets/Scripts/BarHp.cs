using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHp : MonoBehaviour
{
    private const float widthMax = 1.28f;
    [SerializeField] SpriteRenderer spriteHp;

    public void SetRatio(float _ratio)
    {
        spriteHp.size = new Vector2(widthMax * _ratio, spriteHp.size.y);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Unit")]
public class STO_Unit : ScriptableObject
{
    public float HP;
    public float Speed;
    public float Damage;

    public Sprite Sprite_Image;
}

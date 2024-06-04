using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Unit")]
public class STO_Unit : ScriptableObject
{
    public int HP;
    public float Speed;
    public int Damage;
    public Sprite Sprite_Image;
}

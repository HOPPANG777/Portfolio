using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Unit")]
public class STO_Unit : ScriptableObject
{
    public float Unit_HP;
    public float Unit_Speed;
    public float Unit_Damage;

    public Sprite Sprite_Image;
}

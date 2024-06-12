using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Weapon")]
public class STO_Weapon : ScriptableObject
{

    public float Weapon_Damage = 0;
    public float Weapon_Speed = 0;
    public float Weapon_Range = 0;
    public float Weapon_Time = 0;
    public int Weapon_Level = 0;

    public Sprite Sprite_Image;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Weapon_State
{
    public float Weapon_Damage;
    public float Weapon_Speed;
    public float Weapon_Range;
    public float Weapon_Time;
    public int Weapon_Level;
}


[CreateAssetMenu(menuName = "STO/Weapon")]
public class STO_Weapon : ScriptableObject
{

    public float Weapon_Damage = 0;
    public float Weapon_Speed = 0;
    public float Weapon_Range = 0;
    public float Weapon_Time = 0;
    public int Weapon_Level = 0;

    //public Weapon_State[] FDZZ;

    public Sprite Sprite_Image;
}

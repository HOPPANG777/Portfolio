using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Weapon")]
public class STO_Weapon : ScriptableObject
{
    public float damage;
    public int level;
    public float speed;
    public float range;
    public float time;

    public Sprite Sprite_Image;
}

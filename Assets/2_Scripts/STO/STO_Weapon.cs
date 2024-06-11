using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Weapon")]
public class STO_Weapon : ScriptableObject
{

    public float damage = 0;
    public int level = 0;
    public float speed = 0;
    public float range = 0;
    public float time = 0;

    public Sprite Sprite_Image;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "STO/Unit")]
public class STO_Unit : ScriptableObject
{
    // 프리팹이 아니라 그냥 프리팹 없이 게임 오브젝트를 깡으로 생성할수 있다.

    public float Unit_HP;
    public float Unit_Speed;
    public float Unit_Damage;

    public Sprite Sprite_Image;
}

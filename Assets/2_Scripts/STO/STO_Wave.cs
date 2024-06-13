using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Wave_Spawn_Type
{
    //랜덤
    Random,

    //원형으로 둘러싸서 나오기
    Surround,

    //한점에 뭉쳐서 오기
    Dot
}

[CreateAssetMenu(menuName = "STO/Wave")]
public class STO_Wave : ScriptableObject
{
    [Header("어떻게 스폰될까?")]
    public Wave_Spawn_Type WST = Wave_Spawn_Type.Random;

    //나오는 조건
    [Header("나오는 조건")]
    public int Wave_Time = 0;
    public int Kill_Count = 0;

    [Header("나올 시간 0 일경우 무한으로 나옴")]

    //나올 시간 0 일경우 무한으로 나옴
    public int Spawn_Time = 0;

    [Header("얼마나 나올지")]

    //얼마나 나올지
    public int Spawn_Count = 0;

    [Header("나올 애")]

    //나올 애
    public STO_Unit STO_Enemy;
}

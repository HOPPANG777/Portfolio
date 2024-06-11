using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Weapon
{
    public Transform F_target;
    
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}

/*
자 이제 정리해보자 
지금 유닛에서 Push를 완성하고
여기에다가 푸쉬를 불러온다
그리고 플레이어에서 쿨타임을 만들고
쿨타임이 차면 포스를 사용하도록 한다.
아니면 여기다가 쿨타임을 만들수도 있다.
그게 더 쉬울수도 일단 먼저 푸쉬를 만들자

*/
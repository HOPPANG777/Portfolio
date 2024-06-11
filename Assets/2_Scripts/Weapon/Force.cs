using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Force : Weapon
{
    public float F_Radius = 1.0f;

    public Transform F_target;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        var collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, F_Radius);

        float Dis = 10;

        foreach (var collider in collider2Ds)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                var Enemy_Temp = collider.gameObject.GetComponent<Enemy>();

                if (Dis > Vector3.Distance(this.transform.position, Enemy_Temp.transform.position))
                {
                    Dis = Vector3.Distance(this.transform.position, Enemy_Temp.transform.position);
                    F_target = Enemy_Temp.transform;
                }
            }
        }

        if (F_target != null)
        {
            
        }

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
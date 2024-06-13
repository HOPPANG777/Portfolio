using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Force : Weapon
{
    public Enemy F_target;
    public CircleCollider2D CC;

    public override void Start()
    {
        CC = this.AddComponent<CircleCollider2D>();
        CC.isTrigger = true;
        CC.radius = 1f;
        base.Start();
        BC.size = new Vector2(0f, 0f);
        BC.isTrigger = false;
    }

    public override void Update()
    {
        var collider2Ds = Physics2D.OverlapCircleAll(this.transform.position, Weapon_Range);

        float Dis = 10000;
        
        foreach (var collider in collider2Ds)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                var Enemy_Temp = collider.gameObject.GetComponent<Enemy>();

                if (Dis > Vector3.Distance(this.transform.position, Enemy_Temp.transform.position))
                {
                    Dis = Vector3.Distance(this.transform.position, Enemy_Temp.transform.position);
                    F_target = Enemy_Temp;
                }
            }
        }

        if (F_target != null)
        {
            Vector3 Dir = (F_target.transform.position - this.transform.position).normalized;

            Vector3 Knock = Dir * Weapon_Speed;

            F_target.Push(Knock);
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
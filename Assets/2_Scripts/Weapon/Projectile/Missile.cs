using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Weapon
{
    public float TO_Del = 0f;
    public float Dir;
    public float RotateSpeed = 200f;

    public Transform M_target;

    public Vector2 BoxSize = new Vector2(1, 1);

    public override void Start()
    {
        base.Start();
        BC.size = new Vector2(0.35f, 0.356f);
        TO_Del = 7.0f;
    }

    public override void Update()
    {
        //var A = Physics2D.OverlapBoxAll
        //Vector3.Distance()

        var collider2Ds = Physics2D.OverlapBoxAll(this.transform.position, BoxSize, 0); // 이게 그 미사일 주변에서 박스 사이즈 만큼 탐지
        //Dir = Vector2.Distance(this.transform.position, target.position); // 적과 미사일간의 거리

        //상대와 나의 거리
        float Dis = 10000;

        Debug.Log(collider2Ds.Length);

        // C#때 나온 for문 업그레이드 버전
        //배열에 맞춰 요소마다 접근 가능
        foreach(var collider in collider2Ds)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                var Enemy_Temp = collider.gameObject.GetComponent<Enemy>();

                if (Dis > Vector3.Distance(this.transform.position, Enemy_Temp.transform.position))
                {
                    Dis = Vector3.Distance(this.transform.position, Enemy_Temp.transform.position);
                    M_target = Enemy_Temp.transform;
                }
            }
        }


        if (M_target != null)
        {
            Debug.Log("Not Null");

            //방향 바꾸고
            Vector2 Dir = M_target.position - this.transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        }
        else Debug.Log("NULL");
        
        // 그 방향을 향해서 앞으로
        this.transform.position = this.transform.position + this.transform.right * (Weapon_Speed * Time.deltaTime);

        TO_Del -= Time.deltaTime;
        if (TO_Del < 0)
        {
            Destroy(this.gameObject);
        }

    }
    
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.transform.GetComponent<Enemy>())
        {
            Destroy(this.gameObject);
        }


    }

}

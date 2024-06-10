using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Weapon
{
    public float TO_Del = 0.0f;
    public float TO_Count = 5.0f;

    public Transform target;

    public override void Start()
    {
        base.Start();
        BC.size = new Vector2(0.35f, 0.356f);
        if (TO_Del < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            TO_Del = TO_Count;
        }
    }

    public override void Update()
    {
        //var A = Physics2D.OverlapBoxAll
        //Vector3.Distance()

        //방향 바꾸고
        Vector3 dir = target.position - this.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        // 그 방향을 향해서 앞으로
        this.transform.position = this.transform.position + (this.transform.up * speed * Time.deltaTime);

        if (TO_Del > 0)
        {
            TO_Del -= Time.deltaTime;
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

}

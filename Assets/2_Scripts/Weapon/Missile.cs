using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Weapon
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (All_Manager.instance.GameMode_M.Enemy_List != null)
        {
            var target = All_Manager.instance.GameMode_M.Enemy_List.transform;

            // 방향 바꾸고
            // Vector3 dir = target.position - this.transform.position;
            // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            // this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            // 니가 바라보는 정면으로 앞으로 가기
            // this.transform.position = this.transform.position + (this.transform.up * (speed * Time.deltaTime));
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

}

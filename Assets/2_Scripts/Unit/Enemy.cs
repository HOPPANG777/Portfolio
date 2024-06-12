using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public float Attack_Time = 0.0f;
    public float Wating_Attack = 0.0f;

    public override void Start()
    {
        base.Start();
        Attack_Time = 0.0f;
        Wating_Attack = 8.0f;
    }

    public override void Update()
    {
        if (All_Manager.instance.GameMode_M.Current_Player != null)
        {
            var target = All_Manager.instance.GameMode_M.Current_Player.transform;


            //방향 바꾸고
            Vector3 dir = target.position - this.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            //니가 바라보는 정면으로 앞으로 가기
            this.transform.position = this.transform.position + (this.transform.up * (Unit_Speed * Time.deltaTime));
        }

        Attack_Time += Time.deltaTime;
    }

    public override void Hitted(float p_Damage_Value)
    {
        base.Hitted(p_Damage_Value);
    }

    override public void Die()
    {
        base.Die();

        All_Manager.instance.GameMode_M.Enemy_Down();

        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //충돌체가 이 컴포넌트를 가지고 있는가?
        if (collision.transform.GetComponent<Player>())
        {
            if (Attack_Time > Wating_Attack)
            {
                collision.transform.GetComponent<Player>().Hitted(Unit_Damage);

                var Temp = collision.transform.GetComponent<Player>();

                Temp.Hitted(Unit_Damage);

                Debug.Log("Player Hitted");

                Attack_Time = 0.0f;
            }
        }
    }

    public override void Unit_Clear()
    {
        for (int i = All_Manager.instance.GameMode_M.Enemy_List.Count - 1; i >= 0; i--)
        {
            All_Manager.instance.GameMode_M.Enemy_List.Remove(All_Manager.instance.GameMode_M.Enemy_List[i]);
        }
    }

}

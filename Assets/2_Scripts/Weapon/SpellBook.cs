using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpellBook : Weapon
{
    public GameObject Lightning_Go = null;

    public Vector2 BoxSize = new Vector2(3, 3);

    public Enemy M_target = null;

    public override void Start()
    {
        base.Start();
        // Magic();
        Spell();
    }

    public override void Update()
    {
        // Magic();
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

    public void Spell()
    {
        StartCoroutine(C_Spell());
    }

    public IEnumerator C_Spell()
    {
        float Attack_Rate = 10.0f;

        while (true)
        {
            if (All_Manager.instance.GameMode_M.Enemy_List.Count > 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    GameObject Temp_Go = Instantiate(Lightning_Go, All_Manager.instance.GameMode_M.Enemy_List[i].transform.position, Quaternion.identity);

                    if (Temp_Go.GetComponent<Lightning>())
                    {
                        yield return new WaitUntil(() => Temp_Go.GetComponent<Lightning>().SR);
                        All_Manager.instance.Resource_M.Weapon_Stat(Temp_Go.GetComponent<Lightning>(), All_Manager.instance.Resource_M.STO_Lightning);
                    }
                }
            }
            else
            {
                for (int i = 0; i < All_Manager.instance.GameMode_M.Enemy_List.Count; i++)
                {
                    GameObject Temp_Go = Instantiate(Lightning_Go, All_Manager.instance.GameMode_M.Enemy_List[i].transform.position, Quaternion.identity);

                    if (Temp_Go.GetComponent<Lightning>())
                    {
                        yield return new WaitUntil(() => Temp_Go.GetComponent<Lightning>().SR);
                        All_Manager.instance.Resource_M.Weapon_Stat(Temp_Go.GetComponent<Lightning>(), All_Manager.instance.Resource_M.STO_Lightning);
                    }

                    Destroy(Temp_Go, 2.5f);
                }
            }


            yield return new WaitForSeconds(Attack_Rate);
        }


    }


    public void Magic()
    {
        var collider2Ds = Physics2D.OverlapBoxAll(this.transform.position, BoxSize, 0);

        float Dis = 10000f;

        foreach (var collider in collider2Ds)
        {
            if (collider.gameObject.GetComponent<Enemy>())
            {
                var Enemy_Temp = collider.gameObject.GetComponent<Enemy>();

                if (Dis > Vector3.Distance(this.transform.position, Enemy_Temp.transform.position))
                {
                    Dis = Vector3.Distance(this.transform.position, Enemy_Temp.transform.position);
                    M_target = Enemy_Temp;
                }
            }
        }

        if (M_target != null)
        {
            Debug.Log("LNNULL");
            GameObject Temp_Go = Instantiate(Lightning_Go, M_target.transform.position, Quaternion.identity);

            if (Temp_Go.GetComponent<Lightning>())
            {
                if (Temp_Go.GetComponent<Lightning>().SR == null)
                    return;
                All_Manager.instance.Resource_M.Weapon_Stat(Temp_Go.GetComponent<Lightning>(), All_Manager.instance.Resource_M.STO_Lightning);
            }


            Destroy(Temp_Go.gameObject, 2.5f);
        }

    }

}

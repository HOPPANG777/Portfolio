using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SpellBook : Weapon
{
    public GameObject Lightning_Go = null;

    public override void Start()
    {
        base.Start();
        Spell();
    }

    public override void Update()
    {

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
        float Attack_Rate = 5.0f;

        while (true)
        {
            if (All_Manager.instance.GameMode_M.Enemy_List.Count > 10)
            {
                for (int i = 0; i < 10; i++)
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
}

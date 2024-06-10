using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SpellBook : Weapon
{
    public GameObject Lightning_Go = null;

    public override void Start()
    {
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
        float AttackRate = 6.0f;

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
                        Temp_Go.GetComponent<Lightning>().SR.sprite = All_Manager.instance.Resource_M.STO_Lightning.Sprite_Image;
                        Temp_Go.GetComponent<Lightning>().damage = All_Manager.instance.Resource_M.STO_Lightning.damage;
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
                        Temp_Go.GetComponent<Lightning>().SR.sprite = All_Manager.instance.Resource_M.STO_Lightning.Sprite_Image;
                        Temp_Go.GetComponent<Lightning>().damage = All_Manager.instance.Resource_M.STO_Lightning.damage;
                    }
                    Destroy(Temp_Go, 2.5f);
                }
            }

            yield return new WaitForSeconds(AttackRate);
        }

    }

}

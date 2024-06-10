using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Weapon
{
    public GameObject Missile_Go = null;

    public override void Start()
    {
        base.Start();
        Missile_Detected();
    }

    public override void Update()
    {
        base.Update();
    }

    public void Missile_Detected()
    {
        StartCoroutine(C_Missile_Detected());
    }

    public IEnumerator C_Missile_Detected()
    {
        float AttackRate = 2.0f;

        while (true)
        {

            if (All_Manager.instance.GameMode_M.Enemy_List.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject Temp_Go = Instantiate(Missile_Go, null);
                    //Temp_Go.transform.parent = this.transform;


                    //Vector3.Distance()

                    Temp_Go.GetComponent<Missile>().target = All_Manager.instance.GameMode_M.Enemy_List[i].transform;

                    if (Temp_Go.GetComponent<Missile>())
                    {
                        yield return new WaitUntil(() => Temp_Go.GetComponent<Missile>().SR);
                        Temp_Go.GetComponent<Missile>().SR.sprite = All_Manager.instance.Resource_M.STO_Missile.Sprite_Image;
                        Temp_Go.GetComponent<Missile>().damage = All_Manager.instance.Resource_M.STO_Missile.damage;
                        Temp_Go.GetComponent<Missile>().speed = All_Manager.instance.Resource_M.STO_Missile.speed;
                        Temp_Go.GetComponent<Missile>().range = All_Manager.instance.Resource_M.STO_Missile.range;
                        Temp_Go.GetComponent<Missile>().time = All_Manager.instance.Resource_M.STO_Missile.time;
                        Temp_Go.GetComponent<Missile>().level = All_Manager.instance.Resource_M.STO_Missile.level;
                    }

                }
            
            }

            else
            {

                for (int i = 0; i < All_Manager.instance.GameMode_M.Enemy_List.Count; i++)
                {
                    GameObject Temp_Go = Instantiate(Missile_Go, null);
                    //Temp_Go.transform.parent = this.transform;

                    Temp_Go.GetComponent<Missile>().target = All_Manager.instance.GameMode_M.Enemy_List[i].transform;


                    if (Temp_Go.GetComponent<Missile>())
                    {
                        yield return new WaitUntil(() => Temp_Go.GetComponent<Missile>().SR);
                        Temp_Go.GetComponent<Missile>().SR.sprite = All_Manager.instance.Resource_M.STO_Missile.Sprite_Image;
                        Temp_Go.GetComponent<Missile>().damage = All_Manager.instance.Resource_M.STO_Missile.damage;
                        Temp_Go.GetComponent<Missile>().speed = All_Manager.instance.Resource_M.STO_Missile.speed;
                        Temp_Go.GetComponent<Missile>().range = All_Manager.instance.Resource_M.STO_Missile.range;
                        Temp_Go.GetComponent<Missile>().time = All_Manager.instance.Resource_M.STO_Missile.time;
                        Temp_Go.GetComponent<Missile>().level = All_Manager.instance.Resource_M.STO_Missile.level;
                    }

                }

            }

            yield return new WaitForSeconds(AttackRate);
        }
    }
}

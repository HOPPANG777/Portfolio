using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missile_Launcher : Weapon
{
    public GameObject Missile_Go = null;

    public override void Start()
    {
        base.Start();
        Missile_Detected();
    }

    public override void Update()
    {
        
    }

    public void Missile_Detected()
    {
        StartCoroutine(C_Missile_Detected());
    }

    public IEnumerator C_Missile_Detected()
    {
        yield return new WaitUntil(() => Mine);

        float AttackRate = 2.0f;

        while (true)
        {
            //GameObject Temp_Go = Instantiate(Missile_Go, Mine.transform.position, Quaternion.identity, null);
            GameObject Temp_Go = new GameObject("Missile");

            Temp_Go.AddComponent<Missile>();

            Temp_Go.transform.position = Mine.transform.position;
            Temp_Go.transform.rotation = Quaternion.identity;
            Temp_Go.transform.localScale = Vector3.one;

            // Temp_Go.transform.parent = this.transform;
            if (Temp_Go.GetComponent<Missile>())
            {
                yield return new WaitUntil(() => Temp_Go.GetComponent<Missile>().SR);
                Temp_Go.GetComponent<Missile>().SR.sprite = All_Manager.instance.Resource_M.STO_Missile.Sprite_Image;
                All_Manager.instance.Resource_M.Weapon_Stat(Temp_Go.GetComponent<Missile>(), All_Manager.instance.Resource_M.STO_Missile);
            }
            yield return new WaitForSeconds(AttackRate);
        }
    }
}

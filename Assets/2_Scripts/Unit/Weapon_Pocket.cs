using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pocket : MonoBehaviour
{
    public STO_Weapon STO_Projectile;

    public void Init()
    {
        StartCoroutine(E_Init());
    }

    IEnumerator E_Init()
    {
        yield return new WaitWhile(() => STO_Projectile == null);



    }

    // Update is called once per frame
    void Update()
    {

    }
}

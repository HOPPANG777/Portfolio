using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager : MonoBehaviour
{
    public GameObject[] Prefab_Go = null;

    List<GameObject>[] Pools = null;

    private void Awake()
    {
        Pools = new List<GameObject>[Prefab_Go.Length];
        for (int i = 0; i < Pools.Length; i++)
        {
            Pools[i] = new List<GameObject>(); 
        }
    }

    public GameObject GetPool(int index)
    {
        GameObject Sel = null;

        foreach (GameObject item in Pools[index]) 
        { 
            if (!item.activeSelf)
            {
                Sel = item;
                Sel.SetActive(true);
                break;
            }
        }

        if (!Sel)
        {
            Sel = Instantiate(Prefab_Go[index], this.transform);
            Pools[index].Add(Sel);
        }

        return Sel; 
    }

    
}

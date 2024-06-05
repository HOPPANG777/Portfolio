using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Script : MonoBehaviour
{
    public bool AA = true;

    void Start()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        Debug.Log("1");

        //yield return new WaitForSeconds(5.0f);
        //yield return new WaitUntil
        //yield return new WaitWhile
        yield return new WaitWhile(() => AA);

        yield return null;

        Debug.Log("2");
    }


    void Update()
    {
        
    }
}

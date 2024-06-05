using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


//https://unity-programmer.tistory.com/3
public class Bible : Weapon
{
    public Transform center;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        time += speed * Time.deltaTime;
        this.transform.position = center.position + new Vector3(Mathf.Cos(time), Mathf.Sin(time), 0) * range;
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}

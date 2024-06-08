using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : Weapon
{
    public Transform target;

    public float RotateSpeed = 200f;

    public override void Start()
    {
        base.Start();
        BC.size = new Vector2(0.35f, 0.356f);
    }

    public override void Update()
    {
        Vector2 Dir = (Vector2)target.position - RB.position;
        Dir.Normalize();
        float RotateAmount = Vector3.Cross(Dir, transform.up).z;
        RB.angularVelocity = -RotateAmount * RotateSpeed; 
        RB.velocity = transform.up * speed;
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }

}

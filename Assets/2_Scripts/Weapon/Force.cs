using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : Weapon
{
    public override void Start()
    {
        base.Start();
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, range);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(damage, explosionPos, range, 3.0F);
        }
    }

    public override void Update()
    {
        
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}

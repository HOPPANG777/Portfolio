using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Weapon
{
    private Camera mainCamera;
    public override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }

    public override void Update()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(this.gameObject);
        }
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
    }
}

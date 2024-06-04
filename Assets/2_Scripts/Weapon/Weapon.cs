using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    public SpriteRenderer SR;

    public float damage = 0;
    public int level = 0;
    public float speed = 0;
    public float range = 0;

    virtual public void Start()
    {
        BC = this.AddComponent<BoxCollider2D>();
        BC.isTrigger = true;

        RB = this.AddComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
        
        SR = this.AddComponent<SpriteRenderer>();
    }

    virtual public void OnTriggerStay2D(Collider2D collision)
    {
        //충돌체가 이 컴포넌트를 가지고 있는가?
        if (collision.transform.GetComponent<Enemy>())
        {
            collision.transform.GetComponent<Enemy>().Hitted(damage);

            var Temp = collision.transform.GetComponent<Enemy>();

            Temp.Hitted(damage);

            Debug.Log("Enemey Hitted");
        }
    }

}


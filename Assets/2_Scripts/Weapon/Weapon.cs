using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;


public enum Direction_Attack
{
    None,
    Forward,
    LeftRight,
    UpDown
}


public abstract class Weapon : MonoBehaviour
{
    public SpriteRenderer SR;
    public BoxCollider2D BC;
    public Rigidbody2D RB;

    public Unit Mine;

    public float Weapon_Damage = 0;
    public float Weapon_Speed = 0;
    public float Weapon_Range = 0;
    public float Weapon_Time = 0;
    public int Weapon_Level = 0;

    virtual public void Start()
    {
        BC = this.AddComponent<BoxCollider2D>();
        BC.isTrigger = true;

        RB = this.AddComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;

        SR = this.AddComponent<SpriteRenderer>();
    }

    public void Weapon_Init(Unit p_User)
    {
        Mine = p_User;
    }

    virtual public void Update()
    {

    }

    virtual public void OnTriggerStay2D(Collider2D collision)
    {
        //충돌체가 이 컴포넌트를 가지고 있는가?
        if (collision.transform.GetComponent<Enemy>())
        {
            collision.transform.GetComponent<Enemy>().Hitted(Weapon_Damage);

            var Temp = collision.transform.GetComponent<Enemy>();

            Temp.Hitted(Weapon_Damage);

            //Debug.Log("Enemey Hitted");
        }
    }

 

}


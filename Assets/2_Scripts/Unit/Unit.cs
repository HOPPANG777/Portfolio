using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public SpriteRenderer SR;
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    protected bool isDead = false;

    public float Speed = 1.0f;
    public float Xspeed = 2.0f;
    public float Yspeed = 2.0f;

    public float Max_HP = 100;
    public float Current_HP = 100;

    public int damage = 0;
    
    virtual public void Start()
    {
        BC = this.AddComponent<BoxCollider2D>();
        BC.isTrigger = true;

        RB = this.AddComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
        
        SR = this.AddComponent<SpriteRenderer>();
    }

    virtual public void Update()
    {

    }

    virtual public void Hitted(float p_Damage_Value)
    {
        Current_HP -= p_Damage_Value;

        if (Current_HP < 0)
        {
            Current_HP = 0;
            Die();
        }
    }

    virtual public void Die()
    {
        isDead = true;

        this.gameObject.SetActive(false);
    }
}


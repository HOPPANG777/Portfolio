using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

// 추상 : 추상을 적으면 자식만 코드를 사용할수 있고 부모인 자신은 사용하지 못함
public abstract class Unit : MonoBehaviour
{
    public SpriteRenderer SR;
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    protected bool isDead = false;
    protected bool isHit = false;

    //public float Xspeed = 2.0f;
    //public float Yspeed = 2.0f;

    public float Max_HP = 100;
    public float Current_HP = 100;

    public float Unit_Damage = 0.0f;
    public float Unit_Speed = 0.0f;
    public float Unit_HP = 0.0f;

    public float Hit_Effect_Time = 0;

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
        Hit_Effect_Time += Time.deltaTime;
    }

    virtual public void Hitted(float p_Damage_Value)
    {
        Current_HP -= p_Damage_Value;
        if (Current_HP < 0)
        {
            Current_HP = 0;
            Die();
        }
        Hit_Effect();
    }

    virtual public void Die()
    {
        isDead = true;

        this.gameObject.SetActive(false);
    }

    public abstract void Unit_Clear();

    public void Push(Vector3 knockback)
    {
        StartCoroutine(C_Push(knockback));
    }

    public IEnumerator C_Push(Vector3 knockback)
    {
        for(int i=0; i < 100; i++)
        {
            this.transform.position = this.transform.position + (knockback.normalized * 0.001f * (100 - i) * 0.05f);

            yield return null;
        }
    }

    public void Hit_Effect()
    {
        StartCoroutine(C_Hit_Effect());
    }
    
    public IEnumerator C_Hit_Effect()
    {
        isHit = true;
        if (isHit == true)
        {
            SR.color = new Color(1, 0, 0);
        }
       
        yield return new WaitForSeconds(Hit_Effect_Time);

        isHit = false;
        if(isHit == false)
        {
            SR.color = new Color(1, 1, 1);
        }

    }


}

/*
푸쉬를 만드는걸 한번 생각해보자
일단 탑다운이기 때문에 
넉백이 한방향으로만 이루어져선 안된다.
따라서 넉백되는 객체와 넉백을 하는 객체의 
거리와 방향을 구해서 적용해야 한다
하지만 이건 유닛이다 여기서 만들수는 없을꺼 같고 
이걸 버추얼을 해서 플레이어랑 적에서 
만들어야 겠다
그럼 일단 하 시발 이걸 어케 하지
이건 리턴을 해줘야 한단 말이지 
그럼 yield null을 해주거나 다른걸 해줘야 하는데 

*/


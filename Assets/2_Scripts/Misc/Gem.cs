using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gem : MonoBehaviour
{
    public SpriteRenderer SR;
    public BoxCollider2D BC;
    public Rigidbody2D RB;

    public Player Gem_target = null;

    public Vector3 BoxSize = new Vector3(0.1f, 0.1f);

    public void Start()
    {
        BC = this.AddComponent<BoxCollider2D>();
        BC.isTrigger = true;

        RB = this.AddComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;

        SR = this.AddComponent<SpriteRenderer>();
        
    }

    public void Update()
    {
        var collider2Ds = Physics2D.OverlapBoxAll(this.transform.position, BoxSize, 0);

        float Dis = 10000;

        foreach (var collider in collider2Ds)
        {
            if (collider.gameObject.GetComponent<Player>())
            {
                var Player_Temp = collider.gameObject.GetComponent<Player>();

                if (Dis > Vector3.Distance(this.transform.position, Player_Temp.transform.position))
                {
                    Dis = Vector3.Distance(this.transform.position, Player_Temp.transform.position);
                    Gem_target = Player_Temp;
                }
            }
        }

        if (Gem_target != null)
        {
                Debug.Log("Not Null");

                //방향 바꾸고
                Vector2 Dir = Gem_target.transform.position - this.transform.position;
                float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        else Debug.Log("NULL");

        // 그 방향을 향해서 앞으로
        this.transform.position = this.transform.position + this.transform.right * (5.0f * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            All_Manager.instance.GameMode_M.Get_Gem();

            Destroy(this.gameObject);
        }
    }
}

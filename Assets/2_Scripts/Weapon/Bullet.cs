using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField]
    public GameObject projectilePrefab;

    public override void Start()
    {
        
    }

    public override void Update()
    {
        CircleBullet();
    }

    public void CircleBullet()
    {
        C_CircleBullet();
    }

    public IEnumerator C_CircleBullet()
    {
        float IntervalAngle = 360 / level;
        float AttackRate = 0.5f;

        while (true)
        {
            for (int i = 0; i < level; i++)
            {
                GameObject clone = Instantiate(projectilePrefab, this.transform.localPosition, Quaternion.identity);

                if (clone.GetComponent<ProjectilePrefab>())
                {
                    yield return new WaitUntil(() => clone.GetComponent<ProjectilePrefab>().SR);
                    clone.GetComponent<ProjectilePrefab>().SR.sprite = All_Manager.instance.Resource_M.STO_Projectile.Sprite_Image;
                }
                time = IntervalAngle * i;
                float MoveX = Mathf.Cos(time * Mathf.PI / 180.0f);
                float MoveY = Mathf.Sin(time * Mathf.PI / 180.0f);
                Vector2 MoveDir = new Vector2(MoveX, MoveY);
                clone.GetComponent<Rigidbody2D>().AddForce(MoveDir * speed);
            }


            yield return new WaitForSeconds(AttackRate);
        }

    }

}

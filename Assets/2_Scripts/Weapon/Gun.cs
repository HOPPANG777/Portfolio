using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Gun : Weapon
{
    //[SerializeField]
    public GameObject projectilePrefab = null;

    public override void Start()
    {
        CircleBullet();
    }

    public override void Update()
    {

    }

    public void CircleBullet()
    {
        StartCoroutine(C_CircleBullet());
    }

    public IEnumerator C_CircleBullet()
    {
        yield return new WaitUntil(() => Mine);

        float IntervalAngle = 360 / level;
        float AttackRate = 2.0f;

        while (true)
        {

            //for (int i = 0; i < level; i++)
            //{
            //    GameObject clone = Instantiate(projectilePrefab, this.transform.localPosition, Quaternion.identity);
            //
            //    if (clone.GetComponent<ProjectilePrefab>())
            //    {
            //        yield return new WaitUntil(() => clone.GetComponent<ProjectilePrefab>().SR);
            //        clone.GetComponent<ProjectilePrefab>().SR.sprite = All_Manager.instance.Resource_M.STO_Projectile.Sprite_Image;
            //    }
            //
            //    time = IntervalAngle * i;
            //    float MoveX = Mathf.Cos(time * Mathf.PI / 180.0f);
            //    float MoveY = Mathf.Sin(time * Mathf.PI / 180.0f);
            //    Vector2 MoveDir = new Vector2(MoveX, MoveY) * speed;
            //
            //    clone.GetComponent<Rigidbody2D>().AddForce(MoveDir * speed);
            //    // clone.transform.position = clone.transform.position * (clone.transform.up * MoveDir);
            //}

            

            for (int i = 0; i < level; i++)
            {
                GameObject clone = Instantiate(projectilePrefab, this.transform.position + new Vector3(0, 0.3f),
                Quaternion.Euler(0, 0, (360 * i / (level - 1)) + 180)); //투사체의 각도가 자연스럽게 회전값을 넣었다.

                if (clone.GetComponent<ProjectilePrefab>())
                {
                    yield return new WaitUntil(() => clone.GetComponent<ProjectilePrefab>().SR);
                    clone.GetComponent<ProjectilePrefab>().SR.sprite = All_Manager.instance.Resource_M.STO_Projectile.Sprite_Image;
                    clone.GetComponent<ProjectilePrefab>().damage = All_Manager.instance.Resource_M.STO_Projectile.damage;
                    clone.GetComponent<ProjectilePrefab>().speed = All_Manager.instance.Resource_M.STO_Projectile.speed;
                }
                Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI) * 2 * i / (level - 1)), Mathf.Sin((Mathf.PI) * i * 2 / (level - 1)));
                //원을 기준으로 각각의 투사체마다 벡터를 정리
                clone.GetComponent<Rigidbody2D>().AddForce(dirVec * speed * Time.deltaTime);
            }

            yield return new WaitForSeconds(AttackRate);
        }

    }
}

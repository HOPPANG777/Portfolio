using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Bullet_Launcher : Weapon
{
    //[SerializeField]
    public GameObject Bullet_Go = null;

    public override void Start()
    {
        CircleBullet();
        base.Start();
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
        // yield return new WaitUntil(() => Mine);

        // float Interval_Angle = 360 / Weapon_Level;
        float Attack_Rate = 2.0f;

        while (true)
        {

            for (int i = 0; i < Weapon_Level; i++)
            {
                //투사체의 각도가 자연스럽게 회전값을 넣었다.
                GameObject clone = Instantiate(Bullet_Go, this.transform.position + new Vector3(0, 0.3f), Quaternion.Euler(0, 0, (360 * i / (Weapon_Level - 1)) + 180));

                if (clone.GetComponent<Bullet>())
                {
                    yield return new WaitUntil(() => clone.GetComponent<Bullet>().SR);
                    All_Manager.instance.Resource_M.Weapon_Stat(clone.GetComponent<Bullet>(), All_Manager.instance.Resource_M.STO_Bullet);
                    Debug.Log("1");
                }
                Vector3 dirVec = new Vector3(Mathf.Cos((Mathf.PI) * 2 * i / (Weapon_Level - 1)), Mathf.Sin((Mathf.PI) * i * 2 / (Weapon_Level - 1)));
                //원을 기준으로 각각의 투사체마다 벡터를 정리
                //clone.GetComponent<Rigidbody2D>().AddForce(dirVec * Weapon_Speed * Time.deltaTime);
                clone.transform.position = clone.transform.position + (dirVec.normalized * Weapon_Speed * Time.deltaTime);
            }
            
            yield return new WaitForSeconds(Attack_Rate);
        }

    }
}

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


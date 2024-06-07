using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public enum Weapon_Type
{
    None,       // = "없음"
    Bible,      // 성경
    Lightning,  // 플레이어 주변으로 떨어지는 번개
    Bullet,     // 총알 뿌리개
    Missile,    // 유도탄
    Force       // 일정 쿨타임후 주변 밀어냄
}

[System.Serializable]
public class Weapon_Package
{
    public Weapon[] Weapons;
    public Weapon_Type Weapon_Type;
    public int Level;
}


public class Player : Unit
{
    public Vector2 InputVec;

    //찾아보면서 써보기
    public List<Weapon_Package> Weapon_Pocket_List = new List<Weapon_Package>();

    public GameObject Bible_Go = null;
    public GameObject Bullet_Go = null;
    
    public override void Start()
    {
        base.Start();

        Create_Weapon(Weapon_Type.Bible);
        Create_Weapon(Weapon_Type.Bullet);

        // Xspeed = 200;
    }

    public override void Update()
    {
        InputVec.x = Input.GetAxis("Horizontal");
        InputVec.y = Input.GetAxis("Vertical");

        //float xInput = Input.GetAxis("Horizontal");
        //float yInput = Input.GetAxis("Vertical");

        //float xSpeed = xInput * Xspeed * Time.deltaTime;
        //float ySpeed = yInput * Yspeed * Time.deltaTime;

        //앞 뒤으로가기
        // this.transform.position = this.transform.position + (this.transform.up * ySpeed);

        //돌기
        // this.transform.Rotate(new Vector3(0, 0, -xSpeed));

        Vector2 nextVec = InputVec.normalized * (Speed * Time.deltaTime);
        RB.MovePosition(RB.position + nextVec);

        if (InputVec.x != 0)
        {
            SR.flipX = InputVec.x > 0;
        }
    }

    public override void Hitted(float p_Damage_Value)
    {
        base.Hitted(p_Damage_Value);

        All_Manager.instance.UI_M.Update_Player_HPBar_Image(Current_HP / Max_HP);
    }


    public override void Die()
    {
        base.Die();

        All_Manager.instance.GameMode_M.GM_State = GameMode_State.GameOver;

        Destroy(this.gameObject);
    }

    public void Create_Weapon(Weapon_Type p_WT)
    {
        StartCoroutine(C_Create_Weapon(p_WT));
    }

    //무기 만들기
    public IEnumerator C_Create_Weapon(Weapon_Type p_WT)
    {
        switch (p_WT)
        {
            case Weapon_Type.None:
                {

                }
                break;
            case Weapon_Type.Bible:
                {
                    GameObject Temp_Go = Instantiate(Bible_Go, null);
                    Temp_Go.transform.parent = this.transform;
                    if (Temp_Go.GetComponent<Bible>())
                    {
                        yield return new WaitUntil(() => Temp_Go.GetComponent<Bible>().SR);
                        Temp_Go.GetComponent<Bible>().SR.sprite = All_Manager.instance.Resource_M.STO_Bible.Sprite_Image;
                        Temp_Go.GetComponent<Bible>().damage = All_Manager.instance.Resource_M.STO_Bible.damage;
                        Temp_Go.GetComponent<Bible>().speed = All_Manager.instance.Resource_M.STO_Bible.speed;
                        Temp_Go.GetComponent<Bible>().range = All_Manager.instance.Resource_M.STO_Bible.range;
                        Temp_Go.GetComponent<Bible>().time = All_Manager.instance.Resource_M.STO_Bible.time;
                        Temp_Go.GetComponent<Bible>().time = All_Manager.instance.Resource_M.STO_Bible.level;
                    }
                }
                break;
            case Weapon_Type.Lightning:
                {
                }break;
            case Weapon_Type.Bullet:
                {
                    GameObject Temp_Go = Instantiate(Bullet_Go, null);
                    Temp_Go.transform.parent = this.transform;
                    if (Temp_Go.GetComponent<Bullet>())
                    {
                        Temp_Go.GetComponent<Bullet>().damage = All_Manager.instance.Resource_M.STO_Bullet.damage;
                        Temp_Go.GetComponent<Bullet>().speed = All_Manager.instance.Resource_M.STO_Bullet.speed;
                        Temp_Go.GetComponent<Bullet>().range = All_Manager.instance.Resource_M.STO_Bullet.range;
                        Temp_Go.GetComponent<Bullet>().time = All_Manager.instance.Resource_M.STO_Bullet.time;
                        Temp_Go.GetComponent<Bullet>().level = All_Manager.instance.Resource_M.STO_Bullet.level;
                    }
                }
                break;
            case Weapon_Type.Missile:
                {
                }break;
            case Weapon_Type.Force:
                {
                }break;
            default:
                {
                }break;
        }
    }



    //무기 업그레이드
    public void Upgrade_Weapon(Weapon_Type p_WT)
    {

    }

    //가지고 있는지
    public bool Check_Weapon(Weapon_Type p_WT)
    {
        return false;
    }

    //public Weapon_Package Get_Weapon(Weapon_Type p_WT)
    //{
    //
    //}
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public enum Weapon_Type
{
    None,       // = "없음"
    Bible,      // 성경
    SpellBook,  // 플레이어 주변으로 떨어지는 번개
    Gun,     // 총알 뿌리개
    Launchaer,    // 유도탄
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
    public GameObject Gun_Go = null;
    public GameObject SpellBook_Go = null;
    public GameObject Launchaer_Go = null;
    public GameObject Force_Go = null;

    // public float Invincible_Length = 1.0f;
    // public float Invincible_Counter = 0.0f;

    public override void Start()
    {
        base.Start();

        Create_Weapon(Weapon_Type.Bible);
        Create_Weapon(Weapon_Type.Gun);
        Create_Weapon(Weapon_Type.SpellBook);
        Create_Weapon(Weapon_Type.Launchaer);
        Create_Weapon(Weapon_Type.Force);

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

        // Destroy(this.gameObject);
    }

    public void Create_Weapon(Weapon_Type p_WT)
    {
        StartCoroutine(C_Create_Weapon(p_WT));
    }

    //무기 만들기
    public IEnumerator C_Create_Weapon(Weapon_Type p_WT)
    {
        float Skill_Cool = 5.0f;
        float Skill_Full = 0.0f;

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
                        Temp_Go.GetComponent<Bible>().level = All_Manager.instance.Resource_M.STO_Bible.level;
                    }
                }
                break;
            case Weapon_Type.SpellBook:
                {
                    GameObject Temp_Go = Instantiate(SpellBook_Go, null);
                    Temp_Go.transform.parent = this.transform;
                    if (Temp_Go.GetComponent<SpellBook>())
                    {
                        Temp_Go.GetComponent<SpellBook>().damage = All_Manager.instance.Resource_M.STO_SpellBook.damage;
                        Temp_Go.GetComponent<SpellBook>().speed = All_Manager.instance.Resource_M.STO_SpellBook.speed;
                        Temp_Go.GetComponent<SpellBook>().range = All_Manager.instance.Resource_M.STO_SpellBook.range;
                        Temp_Go.GetComponent<SpellBook>().time = All_Manager.instance.Resource_M.STO_SpellBook.time;
                        Temp_Go.GetComponent<SpellBook>().level = All_Manager.instance.Resource_M.STO_SpellBook.level;
                    }
                }
                break;
            case Weapon_Type.Gun:
                {
                    GameObject Temp_Go = Instantiate(Gun_Go, null);
                    Temp_Go.transform.parent = this.transform;
                    if (Temp_Go.GetComponent<Gun>())
                    {
                        Temp_Go.GetComponent<Gun>().damage = All_Manager.instance.Resource_M.STO_Gun.damage;
                        Temp_Go.GetComponent<Gun>().speed = All_Manager.instance.Resource_M.STO_Gun.speed;
                        Temp_Go.GetComponent<Gun>().range = All_Manager.instance.Resource_M.STO_Gun.range;
                        Temp_Go.GetComponent<Gun>().time = All_Manager.instance.Resource_M.STO_Gun.time;
                        Temp_Go.GetComponent<Gun>().level = All_Manager.instance.Resource_M.STO_Gun.level;
                    }
                }
                break;
            case Weapon_Type.Launchaer:
                {
                    GameObject Temp_Go = Instantiate(Launchaer_Go, null);
                    Temp_Go.transform.parent = this.transform;
                }
                break;
            case Weapon_Type.Force:
                {
                    if (Skill_Full < Skill_Cool)
                    {

                        Skill_Full += Time.deltaTime;
                        All_Manager.instance.UI_M.Update_Player_Skill_Image(Skill_Full / Skill_Cool);

                        GameObject Temp_Go = Instantiate(Force_Go, null);
                        Temp_Go.transform.parent = this.transform;
                        if (Temp_Go.GetComponent<Force>())
                        {
                            Temp_Go.GetComponent<Force>().damage = All_Manager.instance.Resource_M.STO_Force.damage;
                            Temp_Go.GetComponent<Force>().speed = All_Manager.instance.Resource_M.STO_Force.speed;
                            Temp_Go.GetComponent<Force>().range = All_Manager.instance.Resource_M.STO_Force.range;
                            Temp_Go.GetComponent<Force>().time = All_Manager.instance.Resource_M.STO_Force.time;
                            Temp_Go.GetComponent<Force>().level = All_Manager.instance.Resource_M.STO_Force.level;
                        }
                    }
                    else
                    {
                        Skill_Full = 0.0f;
                    }
                }
                break;
            default:
                {
                }
                break;
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

    public override void Unit_Clear()
    {
        Destroy(this.gameObject);
    }

    //public Weapon_Package Get_Weapon(Weapon_Type p_WT)
    //{
    //
    //}
}

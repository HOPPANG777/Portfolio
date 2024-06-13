using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ÇÁ¸®ÆÕ Ã¢°í
public class Resource_Manager : MonoBehaviour
{
    public GameObject Player_Prefab_Go;
    public GameObject Enemy_Prefab_Go;

    public STO_Unit STO_Player;
    public STO_Unit STO_Enemy1;
    public STO_Unit STO_Enemy2;
    public STO_Unit STO_Enemy3;
    public STO_Unit STO_Enemy4;
    public STO_Unit STO_Enemy5;
    public STO_Weapon STO_Bible;
    public STO_Weapon STO_Force;
    public STO_Weapon STO_SpellBook;
    public STO_Weapon STO_Bullet_Launcher;
    public STO_Weapon STO_Missile_Launcher;

    public STO_Weapon STO_Missile;
    public STO_Weapon STO_Lightning;
    public STO_Weapon STO_Bullet;

    public STO_Wave[] STO_Waves;

    public void Weapon_Stat(Weapon weapon, STO_Weapon W_STO)
    {
        weapon.SR.sprite = W_STO.Sprite_Image;
        weapon.Weapon_Damage = W_STO.Weapon_Damage;
        weapon.Weapon_Speed = W_STO.Weapon_Speed;
        weapon.Weapon_Range = W_STO.Weapon_Range;
        weapon.Weapon_Time = W_STO.Weapon_Time;
        weapon.Weapon_Level = W_STO.Weapon_Level;
    }

    public void Unit_Stat(Unit unit, STO_Unit Un_STO)
    {
        unit.SR.sprite = Un_STO.Sprite_Image;
        unit.Max_HP = unit.Current_HP = Un_STO.Unit_HP;
        unit.Unit_HP = Un_STO.Unit_HP;
        unit.Unit_Damage = Un_STO.Unit_Damage;
        unit.Unit_Speed = Un_STO.Unit_Speed;  
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Unit_Name
{
    Player,
    Enemy
}

public class Unit_Manager : MonoBehaviour
{
    public GameObject Player_Go;
    public GameObject Enemy_Go;

    public void Create_Unit(Unit_Name p_Unit_Name)
    {
        StartCoroutine(C_Create_Unit(p_Unit_Name));
    }

    //유닛 생성하는 함수
    public IEnumerator C_Create_Unit(Unit_Name p_Unit_Name)
    {
        //플레이어 생성
        if (p_Unit_Name == Unit_Name.Player)
        {
            GameObject Temp_Go = Instantiate(Player_Go, null);
            Temp_Go.transform.position = Vector3.zero;
            Temp_Go.transform.rotation = Quaternion.identity;
            Temp_Go.transform.localScale = Vector3.one;

            //이 게임오브젝트 이 컴포넌트를 갖고 있는지의 bool 값
            if (Temp_Go.GetComponent<Player>())
            {
                Temp_Go.GetComponent<Player>().Max_HP = Temp_Go.GetComponent<Player>().Current_HP = All_Manager.instance.Resource_M.STO_Player.HP;

                //SR이 있을때까지 기다려
                yield return new WaitUntil(() => Temp_Go.GetComponent<Player>().SR);

                Temp_Go.GetComponent<Player>().SR.sprite = All_Manager.instance.Resource_M.STO_Player.Sprite_Image;

                All_Manager.instance.GameMode_M.Current_Player = Temp_Go.GetComponent<Player>();
            }
        }

        // 적 생성
        else if (p_Unit_Name == Unit_Name.Enemy)
        {
            GameObject Temp_Go = Instantiate(Enemy_Go, null);

            //var 란 형태에 맞춰서 변수 타입을 자동으로 받는다
            var Player_Pos = All_Manager.instance.GameMode_M.Current_Player.transform.position;

            //50 - 100 구하고
            //홀이면 플 짝이면 마
            int Temp_X = Random.Range(5, 10);
            Temp_X = ((Temp_X % 2) == 1) ? -Temp_X : Temp_X;

            int Temp_Y = Random.Range(5, 10);
            Temp_Y = ((Temp_Y % 2) == 1) ? -Temp_Y : Temp_Y;

            Player_Pos += new Vector3(Temp_X, Temp_Y, 0);

            Temp_Go.transform.position = Player_Pos;
            Temp_Go.transform.rotation = Quaternion.identity;
            Temp_Go.transform.localScale = Vector3.one;

            yield return new WaitUntil(() => Temp_Go.GetComponent<Enemy>().SR);
            Temp_Go.GetComponent<Enemy>().SR.sprite = All_Manager.instance.Resource_M.STO_Enemy1.Sprite_Image;

            All_Manager.instance.GameMode_M.Enemy_List.Add(Temp_Go.GetComponent<Enemy>());
        }
    }

    //public void Start()
    //{
    //    StartCoroutine(EnemySpawn());
    //}
    //
    //IEnumerator EnemySpawn()
    //{
    //    RandomEnemySpawn();
    //    yield return new WaitForSecondsRealtime(0.7f);
    //}
    //
    //public void RandomEnemySpawn()
    //{
    //    GameObject Temp_Go = Instantiate(Enemy_Go, null);
    //
    //    //var 란 형태에 맞춰서 변수 타입을 자동으로 받는다
    //    var Player_Pos = All_Manager.instance.GameMode_Manager.Current_Player.transform.position;
    //
    //    //50 - 100 구하고
    //    //홀이면 플 짝이면 마
    //    int Temp_X = Random.Range(5, 10);
    //    Temp_X = ((Temp_X % 2) == 1) ? -Temp_X : Temp_X;
    //
    //    int Temp_Y = Random.Range(5, 10);
    //    Temp_Y = ((Temp_Y % 2) == 1) ? -Temp_Y : Temp_Y;
    //
    //    Player_Pos += new Vector3(Temp_X, Temp_Y, 0);
    //
    //    Temp_Go.transform.position = Player_Pos;
    //    Temp_Go.transform.rotation = Quaternion.identity;
    //    Temp_Go.transform.localScale = Vector3.one;
    //}
}

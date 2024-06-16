using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.CanvasScaler;

public enum Unit_Name
{
    Player,
    Enemy
}

public class Unit_Manager : MonoBehaviour
{
    // public GameObject Player_Go;
    // public GameObject Enemy_Go;

    public void Create_Player(STO_Unit P_Unit)
    {
        StartCoroutine(C_Create_Player(P_Unit));
    }

    public IEnumerator C_Create_Player(STO_Unit P_Unit)
    {
        GameObject Player_Go = new GameObject("Player");

        Player_Go.AddComponent<Player>();

        Player_Go.transform.position = Vector3.zero;
        Player_Go.transform.rotation = Quaternion.identity;
        Player_Go.transform.localScale = Vector3.one;

        if (Player_Go.GetComponent<Player>())
        {
            //SR이 있을때까지 기다려
            yield return new WaitUntil(() => Player_Go.GetComponent<Player>().SR);
            All_Manager.instance.Resource_M.Unit_Stat(Player_Go.GetComponent<Player>(), P_Unit);

            All_Manager.instance.GameMode_M.Current_Player = Player_Go.GetComponent<Player>();
        }

    }


    public void Create_Enemy(STO_Unit E_Unit, Vector3 Player_Pos)
    {
        StartCoroutine(C_Create_Enemy(E_Unit, Player_Pos));
    }

    public IEnumerator C_Create_Enemy(STO_Unit E_Unit, Vector3 Player_Pos)
    {
        GameObject Enemy_Go = new GameObject("Enemy");

        Enemy_Go.AddComponent<Enemy>();

        //50 - 100 구하고
        //홀이면 플 짝이면 마
        int Temp_X = Random.Range(5, 10);
        Temp_X = ((Temp_X % 2) == 1) ? -Temp_X : Temp_X;

        int Temp_Y = Random.Range(5, 10);
        Temp_Y = ((Temp_Y % 2) == 1) ? -Temp_Y : Temp_Y;

        Player_Pos += new Vector3(Temp_X, Temp_Y, 0);

        Enemy_Go.transform.position = Player_Pos;
        Enemy_Go.transform.rotation = Quaternion.identity;
        Enemy_Go.transform.localScale = Vector3.one;

        if (Enemy_Go.GetComponent<Enemy>())
        {
            yield return new WaitUntil(() => Enemy_Go.GetComponent<Enemy>().SR);
            All_Manager.instance.Resource_M.Unit_Stat(Enemy_Go.GetComponent<Enemy>(), E_Unit);

            All_Manager.instance.GameMode_M.Enemy_List.Add(Enemy_Go.GetComponent<Enemy>());
        }

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

//public void Create_Unit(Unit_Name p_Unit_Name)
//{
//    StartCoroutine(C_Create_Unit(p_Unit_Name));
//}

////유닛 생성하는 함수
//public IEnumerator C_Create_Unit(Unit_Name p_Unit_Name)
//{
//    //플레이어 생성
//    if (p_Unit_Name == Unit_Name.Player)
//    {
//        GameObject Temp_Go = Instantiate(Player_Go, null);
//        Temp_Go.transform.position = Vector3.zero;
//        Temp_Go.transform.rotation = Quaternion.identity;
//        Temp_Go.transform.localScale = Vector3.one;

//        //이 게임오브젝트 이 컴포넌트를 갖고 있는지의 bool 값
//        if (Temp_Go.GetComponent<Player>())
//        {
//            //SR이 있을때까지 기다려
//            yield return new WaitUntil(() => Temp_Go.GetComponent<Player>().SR);
//            All_Manager.instance.Resource_M.Unit_Stat(Temp_Go.GetComponent<Player>(), All_Manager.instance.Resource_M.STO_Player);

//            All_Manager.instance.GameMode_M.Current_Player = Temp_Go.GetComponent<Player>();
//        }
//    }

//    // 적 생성
//    else if (p_Unit_Name == Unit_Name.Enemy)
//    {
//        GameObject Temp_Go = Instantiate(Enemy_Go, null);

//        //var 란 형태에 맞춰서 변수 타입을 자동으로 받는다
//        var Player_Pos = All_Manager.instance.GameMode_M.Current_Player.transform.position;

//        //50 - 100 구하고
//        //홀이면 플 짝이면 마
//        int Temp_X = Random.Range(5, 10);
//        Temp_X = ((Temp_X % 2) == 1) ? -Temp_X : Temp_X;

//        int Temp_Y = Random.Range(5, 10);
//        Temp_Y = ((Temp_Y % 2) == 1) ? -Temp_Y : Temp_Y;

//        Player_Pos += new Vector3(Temp_X, Temp_Y, 0);

//        Temp_Go.transform.position = Player_Pos;
//        Temp_Go.transform.rotation = Quaternion.identity;
//        Temp_Go.transform.localScale = Vector3.one;

//        if (Temp_Go.GetComponent<Enemy>())
//        {
//            yield return new WaitUntil(() => Temp_Go.GetComponent<Enemy>().SR);
//            All_Manager.instance.Resource_M.Unit_Stat(Temp_Go.GetComponent<Enemy>(), All_Manager.instance.Resource_M.STO_Enemy1);

//            All_Manager.instance.GameMode_M.Enemy_List.Add(Temp_Go.GetComponent<Enemy>());
//        }
//    }
//}
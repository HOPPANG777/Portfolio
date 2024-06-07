using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

//이거 이 타입 유니티에 연결시켜줘 나 하이라키에서 보게
//직렬화
[System.Serializable]
public enum GameMode_State
{
    Idle,
    Ingame,
    GameOver
}

public class GameMode_Manager : MonoBehaviour
{
    public GameMode_State GM_State = GameMode_State.Idle;

    public Player Current_Player = null;
    public List<Enemy> Enemy_List = new List<Enemy>();

    public int Kill_Count = 0;
    public float Spawn_Time = 3;
    public float Spawn_Timer = 0;

    //시간차를 이용해서 만들기
    //이보크 함수 - X
    //Update()
    //코루틴

    void Update()
    {
        if (GM_State == GameMode_State.Ingame)
        {
            //Time.delaTime 1초 만들수 있음
            //
            Spawn_Timer += Time.deltaTime;

            if (Spawn_Timer > Spawn_Time)
            {
                 All_Manager.instance.Unit_M.Create_Unit(Unit_Name.Enemy);

                //Enemy_List.Add(Go.GetComponent<Enemy>());

                Spawn_Timer = 0;
            }
        }

        if (GM_State == GameMode_State.GameOver)
        {
            All_Manager.instance.UI_M.Update_Game_Over_Text_On();
        }
    }


    //게임 시작 함수
    public void Game_Start()
    {
        All_Manager.instance.Unit_M.Create_Unit(Unit_Name.Player);

        GM_State = GameMode_State.Ingame;
    }

    public void Game_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // All_Manager.instance.
        // All_Manager.instance.GameMode_M.Enemy_List.Clear();
        // All_Manager.instance.GameMode_M.GM_State = GameMode_State.Ingame;
        
    }

    public void Game_Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


    public void Enemy_Down()
    {
        Kill_Count++;

        All_Manager.instance.UI_M.Update_Kill_Count_Text(Kill_Count);
    }
}

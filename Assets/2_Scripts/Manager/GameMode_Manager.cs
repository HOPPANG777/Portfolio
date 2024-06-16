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
    public Enemy Current_Enemy = null;
    public List<Enemy> Enemy_List = new List<Enemy>();

    public int Kill_Count = 0;

    //게임시간
    public float Game_Time = 0;

    //
    public List<STO_Wave> Use_STO_Wave_List = new List<STO_Wave>();


    //시간차를 이용해서 만들기
    //이보크 함수 - X
    //Update()
    //코루틴

    void Update()
    {
        if (GM_State == GameMode_State.Ingame)
        {
            Time.timeScale = 1f;

            if (Current_Player == null) return; 

            Game_Time += Time.deltaTime;
            All_Manager.instance.UI_M.Update_Time_Count_Text(Game_Time);

            var Re = All_Manager.instance.Resource_M;

            for(int i = 0; i < Re.STO_Waves.Length; i++)
            {
                //킬 조건이 맞다면
                if (Re.STO_Waves[i].Kill_Count <= Kill_Count)
                {
                    //시간 조건이 맞다면
                    if (Re.STO_Waves[i].Wave_Time <= Game_Time)
                    {
                        //사용중인 웨이브 리스트에 없다면
                        // Contains 이 리스트에 포함 합니까?
                        if (Use_STO_Wave_List.Contains(Re.STO_Waves[i]) == false)
                        {
                            Use_STO_Wave_List.Add(Re.STO_Waves[i]);

                            Start_Wave(Re.STO_Waves[i]);

                            Debug.Log(Re.STO_Waves[i].name + "Start!");
                        }
                    }
                }
            }
        }

        if (GM_State == GameMode_State.GameOver)
        {
            StopAllCoroutines();

            Game_Time = 0;
            Use_STO_Wave_List.Clear();

            All_Manager.instance.UI_M.Update_Game_Over_Text_On();
            Time.timeScale = 0f;
        }
    }


    //게임 시작 함수
    public void Game_Start()
    {
        All_Manager.instance.Unit_M.Create_Player(All_Manager.instance.Resource_M.STO_Player);

        GM_State = GameMode_State.Ingame;
    }

    public void Game_Restart()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // All_Manager.instance.
        // All_Manager.instance.GameMode_M.Enemy_List.Clear();
        // All_Manager.instance.GameMode_M.GM_State = GameMode_State.Ingame;
        All_Manager.instance.UI_M.Update_Game_Over_Text_Off();
        Current_Enemy.Unit_Clear();
        Current_Player.Unit_Clear();
        All_Manager.instance.Unit_M.Create_Player(All_Manager.instance.Resource_M.STO_Player);
        //All_Manager.instance.GameMode_M.GM_State = GameMode_State.Ingame;
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

    public void Start_Wave(STO_Wave p_STO_Wave)
    {
        StartCoroutine(C_Start_Wave(p_STO_Wave));
    }


    public IEnumerator C_Start_Wave(STO_Wave p_STO_Wave)
    {
        if (p_STO_Wave.Spawn_Time == 0)
        {
            while(true)
            {
                if(p_STO_Wave.WST == Wave_Spawn_Type.Random)
                {
                    for (int i = 0; i < p_STO_Wave.Spawn_Count; i++)
                    {
                        // STO 랑 Position 를 매개변수로 받을수 있게
                        //All_Manager.instance.Unit_M.Create_Unit(STO , Position);
                        // All_Manager.instance.Unit_M.Create_Unit(Unit_Name.Enemy);
                        All_Manager.instance.Unit_M.Create_Enemy(All_Manager.instance.Resource_M.STO_Enemy1, All_Manager.instance.GameMode_M.Current_Player.transform.position);
                    }
                }

                else if (p_STO_Wave.WST == Wave_Spawn_Type.Surround)
                {

                }

                else if (p_STO_Wave.WST == Wave_Spawn_Type.Dot)
                {

                }

                yield return new WaitForSeconds(1f);
            }
        }
       
        else
        {

            for(int asd = 0; asd < p_STO_Wave.Spawn_Time; asd++)
            {
                if (p_STO_Wave.WST == Wave_Spawn_Type.Random)
                {
                    for (int qwe = 0; qwe < p_STO_Wave.Spawn_Count; qwe++)
                    {
                        // STO 랑 Position 를 매개변수로 받을수 있게
                        //All_Manager.instance.Unit_M.Create_Unit(STO , Position);
                        All_Manager.instance.Unit_M.Create_Enemy(All_Manager.instance.Resource_M.STO_Enemy1, All_Manager.instance.GameMode_M.Current_Player.transform.position);
                    }
                }

                else if (p_STO_Wave.WST == Wave_Spawn_Type.Surround)
                {

                }

                else if (p_STO_Wave.WST == Wave_Spawn_Type.Dot)
                {

                }

                yield return new WaitForSeconds(1f);
            }
        }


    }

}

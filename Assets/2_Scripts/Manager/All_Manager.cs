using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class All_Manager : MonoBehaviour
{
    public static All_Manager instance = null;

    public UI_Manager UI_M;
    public Unit_Manager Unit_M;
    public GameMode_Manager GameMode_M;
    public Pool_Manager Pool_M;
    public Resource_Manager Resource_M;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}    
    }

    void Start()
    {
        Application.targetFrameRate = 60;

        if (UI_M == null) Debug.Log("UI_Manager 없음");
        if (Unit_M == null) Debug.Log("Unit_Manager 없음");
        if (GameMode_M == null) Debug.Log("GameMode_Manager 없음");
        if (Pool_M == null) Debug.Log("Pool_Manager 없음");
        if (Resource_M == null) Debug.Log("Resource_Manager 없음");

        GameMode_M.Game_Start();
    }

}

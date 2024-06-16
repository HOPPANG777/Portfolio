using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text Kill_Count_Text;
    public Image Player_HPbar_Image;
    public Text Game_Over_Text;
    public Image Player_Skill_Image;
    public Text Time_Count_Text;
    public Text Gem_Count_Text;

    public void Update_Kill_Count_Text(int p_Count)
    {
        Kill_Count_Text.text = "Kill Count : " + p_Count;
    }

    public void Update_Player_HPBar_Image(float p_FillAmount_Value)
    {
        Player_HPbar_Image.fillAmount = p_FillAmount_Value;
    }

    public void Update_Player_Skill_Image(float p_FillAmount_Value)
    {
        Player_Skill_Image.fillAmount = p_FillAmount_Value;
    }

    public void Click_Test()
    {
        Debug.Log("fd");
    }

    public void Update_Game_Over_Text_On()
    {
        Game_Over_Text.gameObject.SetActive(true);
    }

    public void Update_Game_Over_Text_Off()
    {
        Game_Over_Text.gameObject.SetActive(false);
    }

    public void Update_Time_Count_Text(float p_Time_Count)
    {
        Time_Count_Text.text = Mathf.Ceil(p_Time_Count).ToString();
    }

    public void Update_Gem_Count_Text(int p_Gem_Count)
    {
        Gem_Count_Text.text = "Gem : " + p_Gem_Count;
    }
}

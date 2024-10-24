using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private ToggleController tg;
    private bool checkon;
    private void Start()
    {
        tg = GetComponent<ToggleController>();
       
    }

   /* private void Awake()
    {
        LoadSave();
        tg.SetIsOn(checkon);
    }*/
    public void Play() 
    {
        //SaveGame();
        SceneManager.LoadScene("ChooseMode"); 
    }


   /* private void SaveGame()
    {
        PlayerPrefs.SetInt("isOn",checkon ? 1: 0);
        PlayerPrefs.Save();
    }

    private void LoadSave() 
    {
        int savedValue = PlayerPrefs.GetInt("isOn");
        checkon = savedValue == 1 ? true : false;
       
    }*/
}

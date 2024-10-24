using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public Button openSetting;
    public Button closeSetting;
    public Toggle tgMusic;
    public Toggle tgSound;

    public void SettingsOpened() 
    {
        openSetting.gameObject.SetActive(false);
        closeSetting.gameObject.SetActive(true);
        tgMusic.gameObject.SetActive(true);
        tgSound.gameObject.SetActive(true);
        closeSetting.interactable= true;
        
    }

    public void SettingsClosed() 
    {
        openSetting.gameObject.SetActive(true);
        openSetting.interactable= true;
        tgMusic.gameObject.SetActive(false);
        tgSound.gameObject.SetActive(false);
        closeSetting.gameObject.SetActive(false);
       
    }
}

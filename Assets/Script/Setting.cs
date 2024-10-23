using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public Button openSetting;
    public Button closeSetting;
   

    public void SettingsOpened() 
    {
        openSetting.gameObject.SetActive(false);
        closeSetting.gameObject.SetActive(true);
        closeSetting.interactable= true;
    }

    public void SettingsClosed() 
    {
        openSetting.gameObject.SetActive(true);
        openSetting.interactable= true;

        closeSetting.gameObject.SetActive(false);
    }
}

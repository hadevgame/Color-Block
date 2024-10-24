using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleController : MonoBehaviour
{
    public Image on;
    public Image off;
    public Toggle tg;
    private bool ison;

    
    private void Start()
    {
        tg = GetComponent<Toggle>();
       
    }
    private void Update()
    {
        if(tg.isOn == true) 
        {
            off.gameObject.SetActive(false);
            on.gameObject.SetActive(true);
            ison = true;
        }
        else 
        {
            
            on.gameObject.SetActive(false);
            off.gameObject.SetActive(true);
            ison = false;
        }

        
    }

    public void SetIsOn(bool value) 
    {
        ison = value;
    }
    public bool GetIsOn() 
    {
        return ison;
    }
}

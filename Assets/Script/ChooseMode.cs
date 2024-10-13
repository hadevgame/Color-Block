using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMode : MonoBehaviour
{
    public void Mode1() 
    {
        SceneManager.LoadScene("Mode1");
    }
    public void Mode2()
    {
        SceneManager.LoadScene("Mode2");
    }
}

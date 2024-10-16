using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TopBar : MonoBehaviour
{
    public static TopBar instance;
    public TextMeshProUGUI scoreText;
    private int curScore = 0;

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void BackToMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateScore() 
    {
        curScore += 100;
        scoreText.text = curScore.ToString() ;
    }
}

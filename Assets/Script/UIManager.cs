using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;

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

    public void DisplayGameOver()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }

}

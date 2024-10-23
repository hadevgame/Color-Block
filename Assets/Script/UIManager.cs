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
    public TextMeshProUGUI gameoverScoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject gameoverUI;
    public GameObject bestScoreUI;  

    private int curScore = 0;
    private int bestScore = 0;
    
    public void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        LoadSaveData();
    }
    private void Start()
    {
       // this.LoadSaveData();
    }
    public void BackToMenu() 
    {
        SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateScore() 
    {
        curScore += 100;
        scoreText.text = curScore.ToString() ;
    }

    public void DisplayGameOver()
    {
        if(curScore > bestScore) 
        {
            bestScore= curScore;
            bestScoreText.text = bestScore.ToString() ;
            bestScoreUI.SetActive(true);
            Time.timeScale = 0f;
            curScore= 0;
            //SaveGame();
        }
        else 
        {
            gameoverScoreText.text = curScore.ToString();
            gameoverUI.SetActive(true);
            Time.timeScale = 0;
            curScore = 0;
        }
        
    }

    public void Restart()
    {
        SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }

    public void Quit()
    {
        SaveGame();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
    }
    private void LoadSaveData()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        //bestScoreText.text = bestScore.ToString();
    }

}

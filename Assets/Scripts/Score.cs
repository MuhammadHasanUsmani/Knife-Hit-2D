using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoretxt;
    public Text HighScoretext;
    private int CurrentScore = 0;
    private int HighScore;
    public static Score instance;
    public void Awake()
    {
        instance = this;
        PlayerPrefs.SetInt("score", CurrentScore);
        scoretxt.text = PlayerPrefs.GetInt("score").ToString(); 
        HighScoretext.text = PlayerPrefs.GetInt("HighScore").ToString(); 
    }
    public void SetScore()
    {
        print("hi");
        CurrentScore = PlayerPrefs.GetInt("score");
        CurrentScore += 10;
        PlayerPrefs.SetInt("score", CurrentScore);
        string temp = CurrentScore.ToString();
        print("last score " + temp);
        scoretxt.text = temp;

    }
    public void SetHighScore(int LastScore)
    {
        int temp = PlayerPrefs.GetInt("HighScore");
        if (LastScore > temp)
        {
            PlayerPrefs.SetInt("HighScore", LastScore);
            HighScoretext.text = LastScore.ToString();
        }
    }
    public int GetScore()
    {
        return CurrentScore;
    }


}

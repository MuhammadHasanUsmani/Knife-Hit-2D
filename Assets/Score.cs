using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoretxt;
    private int score=0;
    public void Awake()
    {
        PlayerPrefs.SetInt("score", score);
    }
    public void SetScore()
    {
        print("hi");
        score = PlayerPrefs.GetInt("score");
        print("first score "+score);
        score += 10;
        PlayerPrefs.SetInt("score", score);
        print("last score " + score);
        scoretxt.text = score.ToString();


    }


}

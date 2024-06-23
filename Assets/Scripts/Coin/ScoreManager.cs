
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    public static int highCoin = 0;

    void Start()
    {
        text.text = PlayerPrefs.GetInt("coin").ToString();
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        ChangeCoinScore(PlayerPrefs.GetInt("coin"));
    }
    public void ChangeCoinScore(int coinValue)
    {
        //    score += coinValue;
        //    PlayerPrefs.SetInt("coin", score);
        text.text = PlayerPrefs.GetInt("coin").ToString();



    }
}

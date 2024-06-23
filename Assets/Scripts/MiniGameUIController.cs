using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MiniGameUIController : MonoBehaviour
{
    public static MiniGameUIController instance;
    public TextMeshProUGUI scoretext, timertext;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.Log("NO MINIGAMEUICONTROLLER");
    }

    public void UpdateScore(int score)
    {
        scoretext.text = "Score:" + score;
    }

    public void UpdateTimer(float timer)
    {
        timertext.text=string.Format("Time Left: {0}",timer);
    }

    public void GoMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}


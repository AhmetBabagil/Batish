using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;using UnityEngine.UI;
using TMPro;

public class FlappyBirdGameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ScoreTextInGame;
    public GameObject PlayButton;
    public GameObject gameover;
    public GameObject player;
    public ADManager ADManager;

    [Header("SFX")]
   [SerializeField] private AudioClip flappyhit;
    [SerializeField] private AudioClip flappypoint;
  

    private void Awake()
    {
        Application.targetFrameRate = 60;


        Pause();

    }
    public void IncreaseScore()
    {
        score = score + 1;
        ScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("flappybirdhighscore").ToString();
        ScoreTextInGame.text = score.ToString();
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp")+1);
        if (score % 2 == 1) PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);

        if (score > PlayerPrefs.GetInt("flappybirdhighscore")) PlayerPrefs.SetInt("flappybirdhighscore", score);

        SoundManager.instance.PlaySound(flappypoint);
    }
    public void GameOver()
    {
        SoundManager.instance.PlaySound(flappyhit);
        gameover.SetActive(true);
        PlayButton.SetActive(true);
        Pause();
        ADManager.GecisReklamiGoster();
    }
  public void Pause()
    {
       // Time.timeScale = 0f;
        player.SetActive(false);
        
    }
    public void Play()
    {
        score = 0;
        ScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("flappybirdhighscore").ToString();
        ScoreTextInGame.text = score.ToString();

        gameover.SetActive(false);
        PlayButton.SetActive(false);

        Time.timeScale = 1f;
        player.SetActive(true);

        FlappyBirdPipes[] pipes = FindObjectsOfType<FlappyBirdPipes>();
        for(int i =0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

}

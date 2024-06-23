using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongGameManager : MonoBehaviour
{
    private int _playerscore;
    private int _computerscore;

    public PongComputerPaddle computerPaddle;
    public PongPlayerPaddle playerPaddle;

    public PongBall ball;
    public TextMeshProUGUI PlayerScore;
    public TextMeshProUGUI ComputerScore;
    public TextMeshProUGUI streakscore;
    public TextMeshProUGUI highstreakscore;
    public int streakscorecount;

    public ADManager ADManager;

    private void Start()
    {

        streakscore.text = streakscorecount.ToString();
        highstreakscore.text = PlayerPrefs.GetInt("ponghighscore").ToString();
    }
    public void ComputerScores()
    {
        ADManager.GecisReklamiGoster();
        _computerscore++;
        this.ball.ResetPosition();
        SetScores();
        SetPositions();
        CheckGameState();
    }

    public void PlayerScores()
    {
        _playerscore++;
        this.ball.ResetPosition();
        SetScores();
        SetPositions();
        CheckGameState();
    }

    private void SetScores()
    {
        PlayerScore.text = _playerscore.ToString();
        ComputerScore.text = _computerscore.ToString();
    }
    private void SetPositions()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
    }


    private void CheckGameState()
    {
        if (_playerscore == 3)
        {

            ball.ResetPosition();

            this._playerscore = 0;
            this._computerscore = 0; SetScores();
            SetPositions();

            streakscorecount++;

            if (streakscorecount > PlayerPrefs.GetInt("ponghighscore"))
            {
                PlayerPrefs.SetInt("ponghighscore", streakscorecount);
            }
            streakscore.text = streakscorecount.ToString();
            highstreakscore.text = PlayerPrefs.GetInt("ponghighscore").ToString();

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 10);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 10);
        }
        if (_computerscore == 3)
        {
            ball.ResetPosition();

         
            this._playerscore = 0;
            this._computerscore = 0; SetScores();
            SetPositions();
            ADManager.GecisReklamiGoster();
            streakscorecount = 0;
            if (streakscorecount > PlayerPrefs.GetInt("ponghighscore"))
            {
                PlayerPrefs.SetInt("ponghihscore", streakscorecount);
            }
            streakscore.text = streakscorecount.ToString();
            highstreakscore.text = PlayerPrefs.GetInt("ponghighscore").ToString();
        }
    }
}

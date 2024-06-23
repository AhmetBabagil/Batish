using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class AstreoidsGameManager : MonoBehaviour
{
    public AstreoidsPlayer player;
    public int lives = 3;
    public int score = 0;
    public float respawntime=3.0f;
    public float respawnInulnerabilityTime = 3.0f;
    public ADManager ADManager;
    public TextMeshProUGUI currentScoreTEXT;
    public TextMeshProUGUI HighscoreText;

    [Header("SFX")]
    [SerializeField] private AudioClip astreoidDestroyed;

    public void PlayerDied (){
        this.lives--;

        //if (this.lives <= 0)
        if(false)
        {
            GameOver();
        }else

        {
           
            this.player.gameObject.SetActive(false);
            Invoke(nameof(Respawn), this.respawntime);
            this.score = 0;
            DoScoreStuffs();

            ADManager.GecisReklamiGoster();
        }
    }

    private void DoScoreStuffs()
    {
        currentScoreTEXT.text = this.score.ToString();
        if (score > PlayerPrefs.GetInt("astreoidshighscore"))
        {
            PlayerPrefs.SetInt("astreoidshighscore", score);
        }HighscoreText.text = PlayerPrefs.GetInt("astreoidshighscore").ToString();
    }
    private void Respawn()
    {
        this.player.transform.position = Vector3.one;
        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), respawnInulnerabilityTime);
    }
    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("SpaceShip");
    }
    private void GameOver()
    {
        Invoke(nameof(TurnOnCollisions), respawnInulnerabilityTime);
    }
    public void AstreoidDestroyed(AstreoidsAstreoid astreoid)
    {
        SoundManager.instance.PlaySound(astreoidDestroyed);
        
        if (astreoid.size < 0.75f)
        {
            this.score += 100;
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 3);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 3);

        }
        else if(astreoid.size < 1.0f)
        {
            this.score += 50;
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 2);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") +2);
        }
        else
        {
            this.score += 25;
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 1);
        }

        DoScoreStuffs();
    }
}

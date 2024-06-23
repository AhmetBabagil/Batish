
using UnityEngine;

using TMPro;

public sealed class SpaceInvadersGameManager : MonoBehaviour
{
    public SpaceInvadersPlayer player;
    public SpaceInvadersInvaders invaders;
    public SpaceInvadersMysteryShip mysteryShip;
    public SpaceInvadersBunker[] bunkers;

    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI highscoreText;
    public ADManager ADManager;

    public int score;
    public int lives;


  

    private void Start()
    {
        
        player.killed += OnPlayerKilled;
        mysteryShip.killed += OnMysteryShipKilled;
        invaders.killed += OnInvaderKilled;

        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 )
        {
            NewGame();
            
        }
    }

    private void NewGame()
    {
        ADManager.GecisReklamiGoster();
      
        gameOverUI.SetActive(false);

         SetScore(0);
         SetLives(3);

      
        NewRound();
       

    }

    private void NewRound()
    {  
        Respawn();
        invaders.ResetInvaders();

        invaders.gameObject.SetActive(true);

        for (int i = 0; i < bunkers.Length; i++)
        {
          bunkers[i].ResetBunker();
        }

       // Respawn();
    }

    private void Respawn()
    {
        Vector3 position = player.transform.position;
        position.x = 0f;
        player.transform.position = position;
        player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        invaders.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(5, '0');

        if (PlayerPrefs.GetInt("invadershighscore") < score)
            PlayerPrefs.SetInt("invadershighscore", score);
        highscoreText.text = PlayerPrefs.GetInt("invadershighscore").ToString().PadLeft(5, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);
        livesText.text = "x"+lives.ToString();
    }

    private void OnPlayerKilled()
    {
        SetLives(lives - 1);
        ADManager.GecisReklamiGoster();
        player.gameObject.SetActive(false);

        if (lives > 0)
        {
            Invoke(nameof(NewRound), 1f);
        }
        else
        {
            GameOver();
        }
    }

    private void OnInvaderKilled(SpaceInvadersInvader invader)
    {
        SetScore(score + invader.score);

        if (invaders.AmountKilled == invaders.TotalAmount)
        {
            NewRound();
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 50);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 50);
        }
    }

    private void OnMysteryShipKilled(SpaceInvadersMysteryShip mysteryShip)
    {
        SetScore(score + mysteryShip.score);
    }

}
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PacmanGameManager : MonoBehaviour
{
    public PacmanGhost[] ghosts;
    public PacmanPacman pacman;
    public Transform pellets;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI livesText;

    public ADManager ADManager;
    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives = 3;


    [Header("SFX")]
    [SerializeField] private AudioClip introMusic;
    [SerializeField] private AudioClip pacmanMunch;
    [SerializeField] private AudioClip eatingFruit;
    [SerializeField] private AudioClip eatingGhost;
    [SerializeField] private AudioClip intermission;
    [SerializeField] private AudioClip pacmandeath;
       
    private void Start()
    {

      
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 )
        {
            ADManager.GecisReklamiGoster();
            NewGame();
        }
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + score / 100);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + score / 100);

        SetScore(0);
        SetLives(3);
        NewRound();
        SoundManager.instance.PlaySound(introMusic);
    }

    private void NewRound()
    {
        gameOverText.enabled = false;

        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }
        PacmanMovement.isBoostActive = false;
        pacman.gameObject.SetActive(false);
        //GAMEOVEROBJECT SETACTIVE TRUE
        
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "x" + this.lives.ToString();
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');




        if (score > PlayerPrefs.GetInt("pacmanhighscore"))
        {
            PlayerPrefs.SetInt("pacmanhighscore", score);
        }
        hiscoreText.text = PlayerPrefs.GetInt("pacmanhighscore").ToString();
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();

       SoundManager.instance.PlaySound(pacmandeath);
        ADManager.GecisReklamiGoster();

        SetLives(this.lives - 1);
      
        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten(PacmanGhost ghost)
    {
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;

        SoundManager.instance.PlaySound(eatingGhost);
    }

    public void PelletEaten(PacmanPellet pellet)
    {
        SoundManager.instance.PlaySound(pacmanMunch);
        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerPelletEaten(PacmanPowerPellet pellet)
    {
        SoundManager.instance.PlaySound(eatingFruit);
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

}
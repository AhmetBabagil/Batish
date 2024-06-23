using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickBreakerGameManager : MonoBehaviour
{
    public BrickBreakerBall ball;
    public BrickBreakerPaddle paddle;
    public BrickBreakerBrick[] bricks;

    public TextMeshProUGUI liveText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HiscoreText;


    const int NUM_LEVELS = 2;

    public int level = 1;
    public int score = 0;
    public int lives = 3;

    public ADManager admanager;
    private void Update()
    {




        if (PlayerPrefs.GetInt("brickbreakerhighscore") < score)
        {
            PlayerPrefs.SetInt("brickbreakerhighscore", score);
        }
        SetUI();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        lives = 3;
        SetUI();

      //  LoadLevel(1);
    }
    
 

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<BrickBreakerBall>();
        paddle = FindObjectOfType<BrickBreakerPaddle>();
        bricks = FindObjectsOfType<BrickBreakerBrick>();
    }

    public void Miss()
    {
        lives--;

        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    private void ResetLevel()
    {
        paddle.ResetPaddle();
        ball.ResetBall();
        
        admanager.GecisReklamiGoster();
        // Resetting the bricks is optional
        // for (int i = 0; i < bricks.Length; i++) {
        //     bricks[i].ResetBrick();
        // }
    }

    private void GameOver()
    {
        // Start a new game immediately
        // You can also load a "GameOver" scene instead

        for (int i = 0; i < bricks.Length; i++) bricks[i].gameObject.SetActive(true);
        ball.ResetBall();
        paddle.ResetPaddle();
        NewGame();

        admanager.GecisReklamiGoster();
    }

    public void Hit(BrickBreakerBrick brick)
    {
        score += brick.points;
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + brick.points / 10);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + brick.points / 10);

        if (Cleared())
        {
            admanager.GecisReklamiGoster();
        }

   
    }

    private bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }

    private void SetUI()
    {
       scoreText.text=score.ToString();
        liveText.text = lives.ToString();
        HiscoreText.text = PlayerPrefs.GetInt("brickbreakerhighscore").ToString();
    }
}
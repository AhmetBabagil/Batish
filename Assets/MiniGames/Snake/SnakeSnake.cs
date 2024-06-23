using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeSnake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentprefab;

    public int initialsize = 7;

    private int score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI ScoreTextInGame;
    public GameObject PlayButton;
    public GameObject gameover;
    public GameObject player;
    public ADManager ADManager;
    public bool isBoostActive;
    [Header("SFX")]
    public SoundManager instance;
    [SerializeField] private AudioClip flappyhit;
    [SerializeField] private AudioClip flappypoint;

    private void Awake()
    {
    }
    private void Start()
    {isBoostActive = false;
        Play();
        ResetState();
        //  Play();
        //  Pause();
        //    ResetState();
    }
    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
          Mathf.Round(this.transform.position.x) + _direction.x,
          Mathf.Round(this.transform.position.y) + _direction.y,
             0.0f
            );
    }

    public void pressUP()
    {
        _direction = Vector2.up;
    }
    public void pressDOWN()
    {
        _direction = Vector2.down;
    }
    public void pressRIGHT()
    {
        _direction = Vector2.right;
    }
    public void pressLEFT()
    {
        _direction = Vector2.left;
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentprefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        SoundManager.instance.PlaySound(flappypoint);

        if (isBoostActive)
        {
            Transform segment2 = Instantiate(this.segmentprefab);
            segment2.position = _segments[_segments.Count - 1].position;
            _segments.Add(segment2);
            SoundManager.instance.PlaySound(flappypoint);
        }
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialsize; i++)
        {
            _segments.Add(Instantiate(this.segmentprefab));
        }
        this.transform.position = new Vector3(0.0f, 10.5f, 0.0f);
        pressRIGHT();
        isBoostActive = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
            Grow(); IncreaseScore();
        if (other.tag == "Obstavle")
        {
               GameOver();
        }
    }


    public void IncreaseScore()
    {
        score = score + 1; if (isBoostActive) { score++; }
        ScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("snakegamehighscore").ToString();
        ScoreTextInGame.text = score.ToString();
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 1);
        if (score % 2 == 1) PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);

        if (score > PlayerPrefs.GetInt("snakegamehighscore")) PlayerPrefs.SetInt("snakegamehighscore", score);
    }

    public void Play()
    {

        score = 0;
        ScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("snakegamehighscore").ToString();
        ScoreTextInGame.text = score.ToString();

        //    gameover.SetActive(false);
        //   PlayButton.SetActive(false);

        //    Time.timeScale = 1f;
        player.SetActive(true);



    }
    public void GameOver()
    {
        SoundManager.instance.PlaySound(flappyhit);
        //  gameover.SetActive(true);
        //  PlayButton.SetActive(true);
        //   Pause();
        ADManager.GecisReklamiGoster();
        Play();
        ResetState();

    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.SetActive(false);

    }
}

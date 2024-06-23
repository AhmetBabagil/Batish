using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathGameManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI timeText;

    public Button[] answerButtons; // 4 cevap se�ene�i i�in butonlar
    public TextMeshProUGUI[] answerTexts; // Cevap metinleri i�in TextMeshProUGUI dizi
    private int score = 0;
    private float timeLeft = 30.0f;
    private int correctAnswerIndex; // Do�ru cevab�n indexi
    private int difficultyLevel = 1;

    [SerializeField] private ADManager ADManager;
    [SerializeField] private Animator BouAnim;
    void Start()
    {
        if (PlayerPrefs.GetInt("mathgamehighscore") < score)
            PlayerPrefs.SetInt("mathgamehighscore", score);
        highscoreText.text = "best: " + PlayerPrefs.GetInt("mathgamehighscore").ToString();


        if (answerButtons.Length != answerTexts.Length)
        {
            Debug.LogError("Answer buttons and texts arrays must have the same length.");
            return;
        }

        SetupButtons();
        GenerateNewQuestion();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(timeLeft).ToString();
        }
        else
        {
            EndGame();
        }
    }

    private void SetupButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    private void OnAnswerSelected(int index)
    {
        if (index == correctAnswerIndex)
        {
            score += 10; // Do�ru cevap i�in skor art���
            timeLeft += 2.0f; // Do�ru cevap i�in toplam s�reyi 2 saniye art�r
            difficultyLevel++; // Zorluk seviyesini 1 art�r
            scoreText.text = "Score: " + score.ToString();

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 5);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 5);

            BouAnim.SetTrigger("happy");


            if (PlayerPrefs.GetInt("mathgamehighscore") < score)
                PlayerPrefs.SetInt("mathgamehighscore", score);
            highscoreText.text = "best: " + PlayerPrefs.GetInt("mathgamehighscore").ToString();


            GenerateNewQuestion(); // Yeni soru �ret
        }
        else
        {
            // Yanl�� cevap verilirse oyunu bitir ve reklam� g�ster
            EndGame();
            // Reklam g�sterildikten sonra oyunu yeniden ba�lat
            // Bu, reklam SDK'n�z�n sa�lad��� bir callback veya event listener ile yap�lmal�d�r.
            // �rne�in: ADManager.GecisReklamiGoster(() => RestartGame());
        }
    }

    private void GenerateNewQuestion()
    {
        int a = UnityEngine.Random.Range(1, 10 * difficultyLevel);
        int b = UnityEngine.Random.Range(1, 10 * difficultyLevel);
        int correctAnswer = a + b; // �rnek olarak toplama i�lemi
        List<int> options = GenerateOptions(correctAnswer);

        // Do�ru cevab�n index'ini belirle
        correctAnswerIndex = UnityEngine.Random.Range(0, answerButtons.Length);
        // Do�ru cevab� ve di�er se�enekleri kar���k �ekilde yerle�tir
        HashSet<int> placedAnswers = new HashSet<int>();
        while (placedAnswers.Count < 4)
        {
            int randomIndex = UnityEngine.Random.Range(0, options.Count);
            if (!placedAnswers.Contains(randomIndex))
            {
                placedAnswers.Add(randomIndex);
                answerTexts[placedAnswers.Count - 1].text = options[randomIndex].ToString();
                if (randomIndex == 0) // �lk index her zaman do�ru cevab� temsil eder
                {
                    correctAnswerIndex = placedAnswers.Count - 1;
                }
            }
        }

        questionText.text = $"{a} + {b} = ?";
    }

    private List<int> GenerateOptions(int correctAnswer)
    {
        List<int> options = new List<int> { correctAnswer };

        while (options.Count < 4)
        {
            int option;
            do
            {
                option = UnityEngine.Random.Range(1, 10 * difficultyLevel) + UnityEngine.Random.Range(1, 10 * difficultyLevel);
            } while (options.Contains(option) || option == correctAnswer);

            options.Add(option);
        }

        return options;
    }

    // EndGame metodunu g�ncelle
    private void EndGame()
    {
        questionText.text = "Game Over!";
        timeText.text = "Time's Up!";
        // Oyun bitti�inde, butonlar� devre d��� b�rak
        foreach (var button in answerButtons)
        {
            button.interactable = false;
        }

        // Reklam g�sterme fonksiyonunu �a��r
        if (ADManager != null)
        {
            // E�er ADManager bir callback destekliyorsa, burada kullan
            ADManager.GecisReklamiGoster();
        }
        // ADManager'�n reklam g�sterimi bittikten sonra �a��rmak i�in bir mekanizmas� yoksa,
        // burada do�rudan RestartGame() �a��rmak yerine,
        // reklam g�sterimi sonras� tetiklenecek bir mekanizma olu�turmal�s�n�z.
        RestartGame();
    }

    public void RestartGame()
    {
        score = 0;
        timeLeft = 30.0f;
        difficultyLevel = 1;
        scoreText.text = "Score: 0";
        foreach (var button in answerButtons)
        {
            button.interactable = true;
        }
        GenerateNewQuestion();
    }
}

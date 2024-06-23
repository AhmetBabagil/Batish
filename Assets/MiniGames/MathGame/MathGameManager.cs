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

    public Button[] answerButtons; // 4 cevap seçeneði için butonlar
    public TextMeshProUGUI[] answerTexts; // Cevap metinleri için TextMeshProUGUI dizi
    private int score = 0;
    private float timeLeft = 30.0f;
    private int correctAnswerIndex; // Doðru cevabýn indexi
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
            score += 10; // Doðru cevap için skor artýþý
            timeLeft += 2.0f; // Doðru cevap için toplam süreyi 2 saniye artýr
            difficultyLevel++; // Zorluk seviyesini 1 artýr
            scoreText.text = "Score: " + score.ToString();

            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 5);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 5);

            BouAnim.SetTrigger("happy");


            if (PlayerPrefs.GetInt("mathgamehighscore") < score)
                PlayerPrefs.SetInt("mathgamehighscore", score);
            highscoreText.text = "best: " + PlayerPrefs.GetInt("mathgamehighscore").ToString();


            GenerateNewQuestion(); // Yeni soru üret
        }
        else
        {
            // Yanlýþ cevap verilirse oyunu bitir ve reklamý göster
            EndGame();
            // Reklam gösterildikten sonra oyunu yeniden baþlat
            // Bu, reklam SDK'nýzýn saðladýðý bir callback veya event listener ile yapýlmalýdýr.
            // Örneðin: ADManager.GecisReklamiGoster(() => RestartGame());
        }
    }

    private void GenerateNewQuestion()
    {
        int a = UnityEngine.Random.Range(1, 10 * difficultyLevel);
        int b = UnityEngine.Random.Range(1, 10 * difficultyLevel);
        int correctAnswer = a + b; // Örnek olarak toplama iþlemi
        List<int> options = GenerateOptions(correctAnswer);

        // Doðru cevabýn index'ini belirle
        correctAnswerIndex = UnityEngine.Random.Range(0, answerButtons.Length);
        // Doðru cevabý ve diðer seçenekleri karýþýk þekilde yerleþtir
        HashSet<int> placedAnswers = new HashSet<int>();
        while (placedAnswers.Count < 4)
        {
            int randomIndex = UnityEngine.Random.Range(0, options.Count);
            if (!placedAnswers.Contains(randomIndex))
            {
                placedAnswers.Add(randomIndex);
                answerTexts[placedAnswers.Count - 1].text = options[randomIndex].ToString();
                if (randomIndex == 0) // Ýlk index her zaman doðru cevabý temsil eder
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

    // EndGame metodunu güncelle
    private void EndGame()
    {
        questionText.text = "Game Over!";
        timeText.text = "Time's Up!";
        // Oyun bittiðinde, butonlarý devre dýþý býrak
        foreach (var button in answerButtons)
        {
            button.interactable = false;
        }

        // Reklam gösterme fonksiyonunu çaðýr
        if (ADManager != null)
        {
            // Eðer ADManager bir callback destekliyorsa, burada kullan
            ADManager.GecisReklamiGoster();
        }
        // ADManager'ýn reklam gösterimi bittikten sonra çaðýrmak için bir mekanizmasý yoksa,
        // burada doðrudan RestartGame() çaðýrmak yerine,
        // reklam gösterimi sonrasý tetiklenecek bir mekanizma oluþturmalýsýnýz.
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

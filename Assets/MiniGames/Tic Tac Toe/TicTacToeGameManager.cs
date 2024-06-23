using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TicTacToeGameManager : MonoBehaviour
{
    public Button[] buttons;
    public TextMeshProUGUI winnerText, scoreText,highscoreText;
    private int score = 0;
    private bool playerStartsNext = true;
    private string currentPlayer;
    private int moveCount;

    [SerializeField] private ADManager ADManager;
    [SerializeField] private Animator BouAnim;
    void Start()
    {
        CheckHighScore();
        StartNewGame();
    }

    void StartNewGame()
    {
        currentPlayer = playerStartsNext ? "X" : "O";
        moveCount = 0;
        scoreText.text = $"Score: {score}";
        winnerText.text = $"{currentPlayer}'s Turn";
        ResetButtons();

        // If it's computer's turn to start, disable buttons for 1 second
        if (!playerStartsNext)
        {
            SetButtonsInteractable(false);
            StartCoroutine(DelayedComputerTurn());
        }
    }

    void ResetButtons()
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
            button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            button.interactable = true;
            button.onClick.AddListener(() => ButtonClicked(button));
        }
    }

    IEnumerator DelayedComputerTurn()
    {
        yield return new WaitForSeconds(1);
        SetButtonsInteractable(true);
        ComputerTurn();
    }

    void ButtonClicked(Button button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            moveCount++;
            button.GetComponentInChildren<TextMeshProUGUI>().text = currentPlayer;
            button.interactable = false;

            if (CheckWinner() || moveCount == 9)
            {
                EndGame(CheckWinner());
            }
            else
            {
                SwitchPlayer();
            }
        }
    }

    void SwitchPlayer()
    {
        currentPlayer = currentPlayer == "X" ? "O" : "X";
        winnerText.text = $"{currentPlayer}'s Turn";
      //  UpdateBackgroundColor(); // Kamera arka planýný güncelle

        if (currentPlayer == "O")
        {
            SetButtonsInteractable(false);
            StartCoroutine(DelayedComputerTurn());
        }
        else
        {
            SetButtonsInteractable(true);
        }
    }

    void UpdateBackgroundColor()
    {
        if (currentPlayer == "X")
        {
            Camera.main.backgroundColor = Color.green;
        }
        else if (currentPlayer == "O")
        {
            Camera.main.backgroundColor = Color.red;
        }
    }
    void ComputerTurn()
    {
        List<Button> availableButtons = new List<Button>();
        foreach (Button button in buttons)
        {
            if (button.GetComponentInChildren<TextMeshProUGUI>().text == "")
            {
                availableButtons.Add(button);
            }
        }

        if (availableButtons.Count > 0)
        {
            int index = Random.Range(0, availableButtons.Count);
            availableButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = "O";
            availableButtons[index].interactable = false;
            moveCount++;

            if (CheckWinner() || moveCount == 9)
            {
                EndGame(CheckWinner());
            }
            else
            {
                SwitchPlayer();
            }
        }
    }


    bool CheckWinner()
    {
        string[][] winningCombinations = new string[][]
        {
            new string[] { "0", "1", "2" },
            new string[] { "3", "4", "5" },
            new string[] { "6", "7", "8" },
            new string[] { "0", "3", "6" },
            new string[] { "1", "4", "7" },
            new string[] { "2", "5", "8" },
            new string[] { "0", "4", "8" },
            new string[] { "2", "4", "6" }
        };

        foreach (string[] combination in winningCombinations)
        {
            if (buttons[int.Parse(combination[0])].GetComponentInChildren<TextMeshProUGUI>().text == currentPlayer &&
                buttons[int.Parse(combination[1])].GetComponentInChildren<TextMeshProUGUI>().text == currentPlayer &&
                buttons[int.Parse(combination[2])].GetComponentInChildren<TextMeshProUGUI>().text == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    void EndGame(bool isWinner)
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }

        if (isWinner)
        {
            winnerText.text = $"{currentPlayer} Wins!";
            if (currentPlayer == "X") // Oyuncu kazanýrsa skor eklenir
            {
                score += 20;
                PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 10);
                PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 10);
                BouAnim.SetTrigger("happy");
            }
            else if (currentPlayer == "O") // Eðer "X" kaybederse ve "O" kazanýrsa reklam göster
            {
                score = 0; // Skoru sýfýrla
                ADManager.GecisReklamiGoster(); // Reklam göster
   
            }
        }
        else
        {
            winnerText.text = "Draw!";
            score += 5; // Beraberlik durumunda skor eklenir
                        // Berabere durumunda da reklam göstermek istiyorsanýz burada çaðýrýn
            ADManager.GecisReklamiGoster();
        }

        scoreText.text = $"Score: {score}";
        playerStartsNext = !playerStartsNext; // Sýradaki oyunda baþlayacak oyuncuyu deðiþtir
        CheckHighScore(); // Yüksek skoru kontrol et
        StartCoroutine(RestartGame());
    }

    private void CheckHighScore()
    {
        if (PlayerPrefs.GetInt("tictactoehighscore") < score)
            PlayerPrefs.SetInt("tictactoehighscore", score);
        highscoreText.text = "best: " + PlayerPrefs.GetInt("tictactoehighscore").ToString();
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        StartNewGame();
    }

    void SetButtonsInteractable(bool interactable)
    {
        foreach (var button in buttons)
        {
            button.interactable = interactable;
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;

public class ikibinkirksekizGameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;
    public ADManager ADManager;

    private int score;

    private void Start()
    {
      //  NewGame();
    }

    public void NewGame()
    {
        // reset score
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + score / 20);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + score / 20);
        SetScore(0);
        hiscoreText.text = LoadHiscore().ToString();

        // hide game over screen
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        // update board state
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
        ADManager.GecisReklamiGoster();
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore)
        {
            PlayerPrefs.SetInt("2048highscore", score);
        }
    }

    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("2048highscore", 0);
    }

}
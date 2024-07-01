using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Sahne y�netimi i�in ekledik.
using TMPro;
using System.Collections;

public class SuikaGameManager : MonoBehaviour
{
    public int score = 0;
    public Transform dropPosition; // Meyvelerin d��ece�i pozisyon
    public GameObject[] fruitPrefabs; // Meyve prefab'lar� dizisi
    [SerializeField] private Image nextFruitToSpawn; // Spawnlanacak sonraki meyve i�in UI resmi



    [SerializeField] private float dropCooldown = 0.5f; // Meyve d���rme aral��� (saniye cinsinden)
    private float lastDropTime = 0f; // Son meyve d���rme zaman�n� takip etmek i�in
    private int minIndex = 0; // Kullan�lacak meyve endekslerinin minimumu
    private int maxIndex = 3; // Kullan�lacak meyve endekslerinin maksimumu
    private int nextFruitIndex; // S�radaki meyve indexi

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI HiScoreText;
    [SerializeField] private ADManager ADManager;

    public static SuikaGameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateNextFruitToSpawn(); // Ba�lang��ta bir sonraki meyve resmini g�ncelle
        UpdateScore(0); // Ba�lang�� skorunu g�ncelle
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastDropTime >= dropCooldown)
        {
            DropFruit();
        }

   
    }

    void DropFruit()
    {
        lastDropTime = Time.time; // Son d���rme zaman�n� g�ncelle
        GameObject fruit = Instantiate(fruitPrefabs[nextFruitIndex], dropPosition.position, Quaternion.identity); // S�radaki meyve indexini kullanarak meyve olu�tur
        AdjustFruitIndexRange(); // Meyve endeksi aral���n� ayarla
        UpdateNextFruitToSpawn(); // Sonraki meyve i�in resmi g�ncelle
    }



    public void GameOver()
    {
        Debug.Log("Game Over! Showing ad and restarting game...");
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + score/10);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + score / 10);
        ADManager.GecisReklamiGoster();  // Reklam g�sterimi i�in �a�r� yap (AdManager'�n uygun �ekilde tan�mlanmas� gerekiyor)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateNextFruitToSpawn()
    {
        nextFruitIndex = Random.Range(minIndex+(score/100), maxIndex+(score/100)); // Rastgele bir endekste s�radaki meyve se�
        nextFruitToSpawn.sprite = fruitPrefabs[nextFruitIndex].GetComponent<SpriteRenderer>().sprite; // Se�ilen meyvenin sprite'�n� al ve UI'da g�ster
    }

    void AdjustFruitIndexRange()
    {
        if (score >= 100 && maxIndex < fruitPrefabs.Length)
        {
      //      minIndex++;
      //      maxIndex++;
        }
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd; // Skoru g�ncelle
        if (score > PlayerPrefs.GetInt("suikahighscore"))
        {
            PlayerPrefs.SetInt("suikahighscore", score);
        }
        scoreText.text = "score:" + score.ToString();
        HiScoreText.text = "best:" + PlayerPrefs.GetInt("suikahighscore").ToString();
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Sahne yönetimi için ekledik.
using TMPro;
using System.Collections;

public class SuikaGameManager : MonoBehaviour
{
    public int score = 0;
    public Transform dropPosition; // Meyvelerin düþeceði pozisyon
    public GameObject[] fruitPrefabs; // Meyve prefab'larý dizisi
    [SerializeField] private Image nextFruitToSpawn; // Spawnlanacak sonraki meyve için UI resmi



    [SerializeField] private float dropCooldown = 0.5f; // Meyve düþürme aralýðý (saniye cinsinden)
    private float lastDropTime = 0f; // Son meyve düþürme zamanýný takip etmek için
    private int minIndex = 0; // Kullanýlacak meyve endekslerinin minimumu
    private int maxIndex = 3; // Kullanýlacak meyve endekslerinin maksimumu
    private int nextFruitIndex; // Sýradaki meyve indexi

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
        UpdateNextFruitToSpawn(); // Baþlangýçta bir sonraki meyve resmini güncelle
        UpdateScore(0); // Baþlangýç skorunu güncelle
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
        lastDropTime = Time.time; // Son düþürme zamanýný güncelle
        GameObject fruit = Instantiate(fruitPrefabs[nextFruitIndex], dropPosition.position, Quaternion.identity); // Sýradaki meyve indexini kullanarak meyve oluþtur
        AdjustFruitIndexRange(); // Meyve endeksi aralýðýný ayarla
        UpdateNextFruitToSpawn(); // Sonraki meyve için resmi güncelle
    }



    public void GameOver()
    {
        Debug.Log("Game Over! Showing ad and restarting game...");
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + score/10);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + score / 10);
        ADManager.GecisReklamiGoster();  // Reklam gösterimi için çaðrý yap (AdManager'ýn uygun þekilde tanýmlanmasý gerekiyor)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateNextFruitToSpawn()
    {
        nextFruitIndex = Random.Range(minIndex+(score/100), maxIndex+(score/100)); // Rastgele bir endekste sýradaki meyve seç
        nextFruitToSpawn.sprite = fruitPrefabs[nextFruitIndex].GetComponent<SpriteRenderer>().sprite; // Seçilen meyvenin sprite'ýný al ve UI'da göster
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
        score += pointsToAdd; // Skoru güncelle
        if (score > PlayerPrefs.GetInt("suikahighscore"))
        {
            PlayerPrefs.SetInt("suikahighscore", score);
        }
        scoreText.text = "score:" + score.ToString();
        HiScoreText.text = "best:" + PlayerPrefs.GetInt("suikahighscore").ToString();
    }
}

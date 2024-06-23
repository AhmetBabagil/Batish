using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.CinemachineFreeLook;
using TMPro;

public class FruitNinjaGameManager : MonoBehaviour
{
    public GameObject[] fruits; // Meyve prefab'larý burada tutulacak.
    public GameObject[] slicedFruits; // Kesilmiþ meyve prefab'larý burada tutulacak.
    public Transform spawnPoint; // Meyvelerin oluþturulacaðý baþlangýç noktasý.
    public float spawnRate = 1.0f; // Meyve oluþturma hýzý (saniye).
    public TextMeshProUGUI scoreText; // Skorun gösterildiði UI elementi.

    private int score = 0;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnFruit();
        }
    }

    private void SpawnFruit()
    {
        int index = Random.Range(0, fruits.Length);
        GameObject fruit = Instantiate(fruits[index], spawnPoint.position, Quaternion.identity);
        fruit.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100, 100), 300));
        fruit.GetComponent<FruitNinjaFruit>().Setup(slicedFruits[index]);
    }

    public void SliceFruit(GameObject fruit)
    {
        Instantiate(fruit.GetComponent<FruitNinjaFruit>().slicedVersion, fruit.transform.position, fruit.transform.rotation);
        Destroy(fruit);
        IncreaseScore(10);
    }

    private void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }
}

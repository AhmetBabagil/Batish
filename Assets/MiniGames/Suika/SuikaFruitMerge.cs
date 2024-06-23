using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuikaFruitMerge : MonoBehaviour
{
    public int index; // Meyvenin indeksi
    private SuikaGameManager gameManager; // GameManager referansý

    private void Start()
    {
        // GameManager objesini bul ve referansýný al
        gameManager = FindObjectOfType<SuikaGameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    private bool isMerging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SuikaFruitMerge otherFruit = collision.collider.GetComponent<SuikaFruitMerge>();
        if (!isMerging && otherFruit != null && otherFruit.index == this.index && !otherFruit.isMerging)
        {
            isMerging = true;
            otherFruit.isMerging = true;
            MergeFruits(otherFruit);
        }
    }

    private void MergeFruits(SuikaFruitMerge otherFruit)
    {
        if (gameManager != null && otherFruit.index < gameManager.fruitPrefabs.Length - 1)
        {
            GameObject mergedFruitPrefab = gameManager.fruitPrefabs[otherFruit.index + 1];
            Vector3 mergePosition = (transform.position + otherFruit.transform.position) / 2;

            // Meyve birleþmesinde skoru güncelle
            gameManager.UpdateScore(otherFruit.index + 1);

            Destroy(otherFruit.gameObject); // Diðer meyveyi yok et
            Destroy(this.gameObject); // Bu meyveyi yok et

            Instantiate(mergedFruitPrefab, mergePosition, Quaternion.identity);

            // Çarpýþma iþlemini tamamla
            isMerging = false;
        }
    }

    private void Update()
    {
        if (transform.position.y >= 2)
        {
            gameManager.GameOver();
        }
    }

}

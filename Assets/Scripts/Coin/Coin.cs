using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectsound;

    public int coinValue = 0;
    int sum;
    public int coinsum = 0;

    private void Start()
    {

        sum = PlayerPrefs.GetInt("coin", sum);
        PlayerPrefs.GetInt("coin", sum);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Batish"))
        {
            // sum = coinValue;
            SoundManager.instance.PlaySound(collectsound);
            //  PlayerPrefs.SetInt("coin", sum);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin", sum) + coinValue);
            ScoreManager.instance.ChangeCoinScore(PlayerPrefs.GetInt("coin"));

        }

   
    }
}
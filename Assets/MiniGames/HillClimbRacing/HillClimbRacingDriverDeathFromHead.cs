using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillClimbRacingDriverDeathFromHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstavle"))
        {
            HillClimbRacingGameManager.instance.GameOver();
        }
    }
}

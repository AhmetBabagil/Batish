using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillClimbRacingCollectFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HillClimbRacingGameManager.instance.FillFuel();
            Destroy(gameObject);

        }
    }
}

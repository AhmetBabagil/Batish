using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodActivateHelper : MonoBehaviour
{
    public GameObject[] foods;

    private void Start()
    {
        for(int i = 0; i < foods.Length; i++)
        {
            foods[i].SetActive(false);
        }
    }

    private void Update()
    {
        for (int i = 0; i < foods.Length; i++)
        {
            if (PlayerPrefs.GetInt("food" + i) >= 1)
            {
                foods[i].SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ClosetactivateHelper : MonoBehaviour
{
    [SerializeField] public GameObject[] hairs;
    [SerializeField] public GameObject[] clothes;
    [SerializeField] public GameObject[] accesories;


    public RemovePriceWhenBuyed removePriceWhenBuyed;

    private void Awake()
    {
        removePriceWhenBuyed = GetComponent<RemovePriceWhenBuyed>();
    }

    private void Start()
    {
        for(int i = 0; i < hairs.Length; i++)
        {
            hairs[i].SetActive(false);
        }
        for(int i = 0; i < clothes.Length; i++)
        {
            clothes[i].SetActive(false);    
        }
        for (int i = 0; i < accesories.Length; i++)
        {
            accesories[i].SetActive(false);
        }


        CheckIfActive();
    }
    private void Update()
    {
       // CheckIfActive();
    }
    public void CheckIfActive()
    {
        for(int i = 0; i < hairs.Length; i++)
        {
            if (PlayerPrefs.GetInt("hair"+i) == 1 && PlayerPrefs.GetInt("hair"+i+"payed")==1 )
            {
                hairs[i].SetActive(true);
                removePriceWhenBuyed.hairs[i].SetActive(false);
            }
        }

        for (int i = 0; i < clothes.Length; i++)
        {
            if (PlayerPrefs.GetInt("clothes" + i) == 1 && PlayerPrefs.GetInt("clothes" + i + "payed") == 1)
            {
                clothes[i].SetActive(true);
                removePriceWhenBuyed.clothes[i].SetActive(false);
            }
        }

        for (int i = 0; i < accesories.Length; i++)
        {
            if (PlayerPrefs.GetInt("accesories" + i) == 1 && PlayerPrefs.GetInt("accesories" + i + "payed") == 1)
            {
                accesories[i].SetActive(true);
                removePriceWhenBuyed.accesories[i].SetActive(false);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////remove labels
        for (int i = 0; i < hairs.Length; i++)
        {
            if (PlayerPrefs.GetInt("hair" + i + "payed") == 1)
            {
                removePriceWhenBuyed.hairs[i].SetActive(false);
            }
        }

        for (int i = 0; i < accesories.Length; i++)
        {
            if (PlayerPrefs.GetInt("accesories" + i + "payed") == 1)
            {
                removePriceWhenBuyed.accesories[i].SetActive(false);
            }
        }

        for (int i = 0; i < clothes.Length; i++)
        {
            if (PlayerPrefs.GetInt("clothes" + i + "payed") == 1)
            {
                removePriceWhenBuyed.clothes[i].SetActive(false);
            }
        }

    }
}

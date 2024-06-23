using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferActivator : MonoBehaviour
{

  [SerializeField]  private GameObject obj1;
 [SerializeField]   private  GameObject obj2;
    void Start()
    {
        PlayerPrefs.SetInt("openmarkethelper", PlayerPrefs.GetInt("openmarkethelper") + 1);
        if (PlayerPrefs.GetInt("openmarkethelper") % 3 == 0 && PlayerPrefs.GetInt("subisbuyed")==0)//////////////////77sonradan deðiþtirildi
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
        }
        else
        {
    
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    public string abonelikName= "com.mybou.abonelik1";
    public string reklamlarikaldir = "com.mybou.reklamlarikaldir";
    public string level1 = "com.mybou.level1";
    public string level2 = "com.mybou.level2";
    public string level3 = "com.mybou.level3";
    public string level4 = "com.mybou.level4";
    public string level5 = "com.mybou.level5";
    public string level6 = "com.mybou.level6";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id==abonelikName)
        {
            PlayerPrefs.SetInt("removeads", 1);
            PlayerPrefs.SetInt("doubleprofitonminigames", 1);
            PlayerPrefs.SetInt("subisbuyed", 1);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == reklamlarikaldir)
        {
            PlayerPrefs.SetInt("removeads", 1);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level1)
        {
            PlayerPrefs.SetInt("coin",PlayerPrefs.GetInt("coin") + 4000);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level2)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 12000);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level3)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 28000);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level4)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 60000);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level5)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 150000);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == level6)
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 400000);
        }
    }

    public void OnPurchaseFailed(Product product,PurchaseFailureReason reason)
    {
        if (product.definition.id == abonelikName)
        {
            PlayerPrefs.SetInt("removeads", 0);
            PlayerPrefs.SetInt("doubleprofitonminigames", 0);
            PlayerPrefs.SetInt("subisbuyed", 0);
        }
        //////////////////////////////////////////////////////////////////////////
        if (product.definition.id == reklamlarikaldir)
        {
            PlayerPrefs.SetInt("removeads", 0);
        }

    }
}

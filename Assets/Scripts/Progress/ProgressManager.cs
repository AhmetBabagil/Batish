
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;
using System.Xml.XPath;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;
    public TextMeshProUGUI text;


    public GameObject xp1;
    public GameObject xp2;
    public GameObject xp3;
    public GameObject xp4;

 

    public void DoXPUIThings()
    {
        ChangeXPScoreValue();
        ChangeXPUI();
    }
    void Start()
    {
      
        DoXPUIThings();
    }
    public void ChangeXPScoreValue()
    {
        text.text = (PlayerPrefs.GetInt("xp") / 100).ToString();
    }

    public void ChangeXPUI()
    {
        if((PlayerPrefs.GetInt("xp")%100)<100    &&    (PlayerPrefs.GetInt("xp") % 100) >= 75)
        {
            xp1.SetActive(true);
            xp2.SetActive(false);
            xp3.SetActive(false);
            xp4.SetActive(false);
        }

        if ((PlayerPrefs.GetInt("xp") % 100) < 75 && (PlayerPrefs.GetInt("xp") % 100) >= 50)
        {
            xp1.SetActive(false);
            xp2.SetActive(true);
            xp3.SetActive(false);
            xp4.SetActive(false);
        }

        if ((PlayerPrefs.GetInt("xp") % 100) < 50 && (PlayerPrefs.GetInt("xp") % 100) >= 25)
        {
            xp1.SetActive(false);
            xp2.SetActive(false);
            xp3.SetActive(true);
            xp4.SetActive(false);
        }

        if ((PlayerPrefs.GetInt("xp") % 100) < 25 && (PlayerPrefs.GetInt("xp") % 100) >= 0)
        {
            xp1.SetActive(false);
            xp2.SetActive(false);
            xp3.SetActive(false);
            xp4.SetActive(true);
        }
    }
}
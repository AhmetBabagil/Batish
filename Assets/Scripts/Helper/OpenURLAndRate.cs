using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURLAndRate : MonoBehaviour
{
    public GameObject Rate5Holder;
    void Start()
    {
        PlayerPrefs.SetInt("rate5counter", PlayerPrefs.GetInt("rate5counter")+1);
        if (PlayerPrefs.GetInt("rate5counter") == 3)//////////////////77sonradan deðiþtirildi
        {
            Rate5Holder.SetActive(true);
        }else
        {
            Rate5Holder.SetActive(false);
        }
    }

    public void Rate()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.AhmetBabagil.MyBou");
        PlayerPrefs.SetInt("rate5counter", PlayerPrefs.GetInt("rate5counter") + 1);
#elif UNITY_IPHONE

#endif
        Rate5Holder.SetActive(false);
    }
}

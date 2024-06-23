using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioClip clicksound;
    [SerializeField] private AudioClip lightsON;
    [SerializeField] private AudioClip lightsOFF;

    private void Awake()
    {
        if (instance == null) instance = this;
        else return;
    }
    public  void playClickSound()
    {
        SoundManager.instance.PlaySound(clicksound);
    }
    public void playlightsONSound()
    {
        SoundManager.instance.PlaySound(lightsON);
    }
    public void playlightsSOFFSound()
    {
        SoundManager.instance.PlaySound(lightsOFF);
    }
}

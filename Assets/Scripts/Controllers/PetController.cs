using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PetController : MonoBehaviour
{
    public Animator petanimator;
    private Vector3 destination;
    public float speed;
    public PetManager PetManager;
    public Button happinesClickButton;

    [Header("SFX")]
    [SerializeField] private AudioClip sincap1;
    [SerializeField] private AudioClip sincap2;
    [SerializeField] private AudioClip sincap3;
    [SerializeField] private AudioClip sincap4;
    [SerializeField] private AudioClip eatsound;



    private void Awake()
    {

    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position,destination,speed*Time.deltaTime);
        }
    }
    public void Move(Vector3 destination)
    {
        this.destination = destination;
    }

    public void Jump() {
        petanimator.SetTrigger("jump");
    }
    public void Happy()
    {
        petanimator.SetTrigger("happy");
        speed = 5;PetManager.originalpetmovetimer = 1;
    }
    public void Okay()
    {
        petanimator.SetTrigger("okay");
        speed = 4; PetManager.originalpetmovetimer = 2;
    }
    public void SoSad()
    {
        petanimator.SetTrigger("sosad");
        speed = 3; PetManager.originalpetmovetimer = 3;
    }
    public void Sad()
    {
        petanimator.SetTrigger("sad");
        speed = 2; PetManager.originalpetmovetimer = 4;
    }
    public void Sick()
    {
        petanimator.SetTrigger("sick");
        speed = 1; PetManager.originalpetmovetimer = 5;
    }
    public void Eat()
    {
        petanimator.SetTrigger("eat");
        SoundManager.instance.PlaySound(eatsound);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 30);
    }
    public void Drink()
    {
        petanimator.SetTrigger("drink");
    }
    public void Sleep()
    {
        speed = 0;
        
    }
    public void WakeUp()
    {
        speed = 2;
    }

    public void OnClickHappines() {
        float randomNumber = UnityEngine.Random.Range(0f, 10f);
        if(randomNumber < 2.5 && randomNumber > 0)
        {
            Zipla();SoundManager.instance.PlaySound(sincap1);
        }else if(randomNumber < 5 && randomNumber > 2.5)
        {
            Yuvarlan(); SoundManager.instance.PlaySound(sincap2);
        }
        else if(randomNumber<7.5 && randomNumber > 5)
        {
            SagaZipla(); SoundManager.instance.PlaySound(sincap3);
        }
        else if (randomNumber < 10 && randomNumber > 7.5)
        {
            SolaZipla(); SoundManager.instance.PlaySound(sincap4);
        }
        Invoke("HappinessClickButtonSetActive", 1);
    }
    public void Zipla()
    {
        petanimator.SetTrigger("zipla");
    }
    public void Yuvarlan()
    {
        petanimator.SetTrigger("yuvarlan");
    }

    public void SagaZipla()
    {
        petanimator.SetTrigger("sagazipla");
    }

    public void SolaZipla()
    {
        petanimator.SetTrigger("solazipla");
    }
    
    private void HappinessClickButtonSetActive()
    {
        happinesClickButton.gameObject.SetActive(true);
    }
 
}

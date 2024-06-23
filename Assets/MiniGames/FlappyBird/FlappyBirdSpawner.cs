using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class FlappyBirdSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnrate =1f;
    public float maxheigth = 1.5f;
    public float minheigth = -1.5f;
    public static bool isBoostActive=false;
    public TextMeshProUGUI timetext;

    public void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
    
        GameObject pipes=Instantiate(prefab,transform.position,Quaternion.identity);
        if(!isBoostActive)
        pipes.transform.position += Vector3.up* Random.Range(minheigth, maxheigth);
        if(isBoostActive)
        pipes.transform.position += Vector3.up * Random.Range(minheigth+0.5f, maxheigth-0.5f);
    }

    private float starttime = 60f;
    private float currenttime = 0f;

    private void Start()
    {
        currenttime = starttime;
    }
    private void Update()
    {
        if (isBoostActive)
        {
            currenttime = currenttime - Time.deltaTime;
            timetext.text = currenttime.ToString();
            if (currenttime < 0)
            {
                currenttime = starttime;
                timetext.text = currenttime.ToString();
                isBoostActive = false;
            }
        }
    }

}

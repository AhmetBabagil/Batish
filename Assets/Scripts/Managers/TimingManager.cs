using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public  float gamehourtimer;
    public  float hourlength;

    public static TimingManager instance;

    public void Awake()
    {
        if (instance == null) instance = this;
        else Debug.Log("more than 1 timingmanager in the scene");
    }
    private void Update()
    {
        if (gamehourtimer <= 0)
        {
            gamehourtimer = hourlength;
        }
        else {

            gamehourtimer -= Time.deltaTime;
        }
    }
}

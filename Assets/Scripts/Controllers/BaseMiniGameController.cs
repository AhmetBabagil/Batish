using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMiniGameController : MonoBehaviour
{
    public float timer;
    public GameObject minigameuiend;
   protected virtual void ChangeTimer(float change)
    {
        timer+=change;
        MiniGameUIController.instance.UpdateTimer(timer);
    }

    protected virtual void Update()
    {
        ChangeTimer(-Time.deltaTime);
        if (timer < 0)
        {
            minigameuiend.SetActive(true);
        }
    }
}

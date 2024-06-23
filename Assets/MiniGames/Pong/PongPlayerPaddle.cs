using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongPlayerPaddle : PongPaddle
{
    private Vector2 _direction;

    private int direction = 0;

    private void FixedUpdate()
    {
        if (direction == 0)
        {
            _direction = Vector2.zero;
        }
        else if (direction == 1)
        {
            _direction = Vector2.left;
        }
        if (direction == 2)
        {
            _direction = Vector2.right;
        }



        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody2.AddForce(_direction*this.speed);   
        }
    }
    public void LeftButton()
    {
        this.direction = 1;
    }
    public void RightButton()
    {
        this.direction = 2;
    }

    public void EliniKaldirinca()
    {
        this.direction = 0;
    }
    ///////////////////////////////////////////////////////
    ///


    private float starttime = 60f;
    private float currenttime = 0f;
    public TextMeshProUGUI timetext;
    public static bool isBoostActive;

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
                this.gameObject.transform.localScale = new Vector3(1,1,1);
            }
        }
    }

}

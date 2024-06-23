using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AstreoidsPlayer : MonoBehaviour
{
    public AstreoidsBullet bulletPrefabs;
    public float turnspeed=1.0f;
    public float thrustspeed=1.0f;
    public Rigidbody2D rb;
    private bool thrusting;
    private float turndirection;
    private int flyingstate = -1;

    [Header("SFX")]
    [SerializeField] private AudioClip astreoidshoot;

    private void Update()
    {
     //   thrusting=Input.GetKey(KeyCode.W);
        if (Input.GetKey(KeyCode.A))
        {
            turndirection = 1.0f;
        }else if (Input.GetKey(KeyCode.D))
        {
            turndirection = -1.0f;
        }else
        {
            turndirection = 0.0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        ////////////////////////////////////////////


    }

    private void FixedUpdate()
    {
        if (flyingstate == 0)
        { turndirection = 1.0f; }
        else if (flyingstate == 1) { turndirection = -1.0f; }
        else turndirection = 0.0f;


        if (thrusting)
        {
            rb.AddForce(this.transform.up*this.thrustspeed) ;
        }
        if (turndirection != 0.0f)
        {
            rb.AddTorque(turndirection * this.turnspeed);
        }
    }
    public void LEFT()
    {
        flyingstate = 0;
    }
    public void RIGHT()
    {
        flyingstate = 1;
    }
    public void NOROTATE()
    {
        flyingstate = 2;
    }
    public void YESFLY()
    {
        this.thrusting = true;
    }
    public void NOFLY()
    {
        this.thrusting = false;
    }

    public void Shoot()
    {
        AstreoidsBullet bullet = Instantiate(this.bulletPrefabs
            , this.transform.position, this.transform.rotation);

        bullet.Project(this.transform.up);
        SoundManager.instance.PlaySound(astreoidshoot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astreoid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<AstreoidsGameManager>().PlayerDied();
        }
    }





    private float starttime = 60f;
    private float currenttime = 0f;
    public static bool isBoostActive = false;
    public TextMeshProUGUI timetext;


    private void LateUpdate()
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
                turnspeed /= 2;
                thrustspeed /= 2;
            }
        }
    }
}

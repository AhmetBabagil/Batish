using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpaceInvadersPlayer : MonoBehaviour
{
    public SpaceInvadersProjectile laserPrefab;
    public float speed = 5.0f;
    int movestate = -1;
    private bool laserActive;
    public System.Action killed;

    [Header("SFX")]
    [SerializeField] private AudioClip astreoidshoot;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        if (movestate == 0)
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (movestate == 1)
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (!laserActive)
        { SpaceInvadersProjectile projectile=
            Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += OnLaserDestroyed;
            laserActive = true;
            SoundManager.instance.PlaySound(astreoidshoot);
        }
    }

    public void LEFTBUTTON()
    {
        movestate = 0;
    }
        public void RIGHTBUTTON()
    {
        movestate = 1;
    }
    public void STOPMOVINGBUTTON()
    {
        movestate = -1;
    }
    private void LaserDestroyed()
    {
        laserActive = false;
    }

    private void OnLaserDestroyed(SpaceInvadersProjectile laser)
    {
        laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") ||
            other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            if (killed != null)
            {
                killed.Invoke();
            }
        }
    }
}

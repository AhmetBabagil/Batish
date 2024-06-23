using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidsBullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float maxLifetime = 10.0f;
    public Rigidbody2D rigidbody;
    
    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction*speed);
        Destroy(this.gameObject, this.maxLifetime);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

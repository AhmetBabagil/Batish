using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PongBall ball=collision.gameObject.GetComponent<PongBall>();

        if(ball!= null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal*this.bounceStrength);
        }
    }
}

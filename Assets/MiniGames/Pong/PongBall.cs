using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed = 10.0f;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();  
    }
    private void Start()
    {
        ResetPosition();
    }
    private void AddStartingForce()
    {
        float y = (Random.value <= 0.5f) ? -1.0f : 1.0f;
        float x = (Random.value <= 0.5f) ? Random.Range(-1.0f, -0.5f) :
             Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        Rigidbody2D.AddForce(direction * this.speed);
    }
    public void AddForce(Vector2 force)
    {
        Rigidbody2D.AddForce(force);
    }

    public void ResetPosition()
    {
        Rigidbody2D.position= Vector2.zero;
        Rigidbody2D.velocity = Vector2.zero;

        AddStartingForce();
    }
}

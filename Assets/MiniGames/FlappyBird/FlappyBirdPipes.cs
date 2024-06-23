using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPipes : MonoBehaviour
{
    public float speed = 5f;
    private float leftedge;

    private void Start()
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x-3f;
    }
    private void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;
        if (transform.position.x < leftedge) { Destroy(gameObject); }
    }
}

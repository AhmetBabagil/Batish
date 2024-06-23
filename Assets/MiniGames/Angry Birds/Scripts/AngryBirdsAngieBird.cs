using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdsAngieBird : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider2D;

    private bool _hasBeenLaunched;
    private bool _ShouldFaceVelocityDireciton;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _circleCollider2D=GetComponent<CircleCollider2D>();

    }

    private void Start()
    {

        _rb.isKinematic = true;
        _circleCollider2D.enabled = false;
    }

    private void FixedUpdate()
    {
        if(_hasBeenLaunched && _ShouldFaceVelocityDireciton)
        {
            transform.right = _rb.velocity;
        }
       
    }
    public void LaunchBird(Vector2 direction , float force)
    {
        _rb.isKinematic = false;
        _circleCollider2D.enabled = true;

        _rb.AddForce(direction * force, ForceMode2D.Impulse);
    
        _hasBeenLaunched = true;
        _ShouldFaceVelocityDireciton = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ShouldFaceVelocityDireciton = false;
    }
}

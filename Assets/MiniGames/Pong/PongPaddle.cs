using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPaddle : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2;
    public float speed= 10.0f;

    private void Awake()
    {
        _rigidbody2 = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody2.position=new Vector2(0.0f, _rigidbody2.position.y);
        _rigidbody2.velocity = Vector2.zero;
    }
}

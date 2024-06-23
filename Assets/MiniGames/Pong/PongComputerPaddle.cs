using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongComputerPaddle : PongPaddle
{

    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        if (this.ball.velocity.x > 0.0f)
        {
            if (this.ball.position.x > this.transform.position.x)
            {
                _rigidbody2.AddForce(Vector2.right * this.speed);
            }
            else if (this.ball.position.x < this.transform.position.x)
            {
                _rigidbody2.AddForce(Vector2.left * this.speed);
            }
        }
        else
        {
            if(this.transform.position.x>0.0f)
            {
                _rigidbody2.AddForce(Vector2.left * this.speed);
            }else if(this.transform.position.x < 0.0f)
            {
                this._rigidbody2.AddForce(Vector2.right * this.speed);
            }
        }
        
    }


}

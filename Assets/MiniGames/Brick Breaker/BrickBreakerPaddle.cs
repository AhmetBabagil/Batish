using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BrickBreakerPaddle : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxBounceAngle = 75f;
    private int movestate = 0;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPaddle();
        currenttime=starttime;
    }

    public void ResetPaddle()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(0f, transform.position.y);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }


        if (movestate == 1)
        {
            direction = Vector2.left;
        }
        if (movestate == 2)
        {
            direction = Vector2.right;
        }
        if (movestate == 0)
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {

        if (direction != Vector2.zero)
        {
            rigidbody.AddForce(direction * speed);
        }
       
    }
    public void MOVERIGHT() { movestate = 2; }
    public void MOVELEFT() { movestate = 1; }
    public void STOPMOVE() { movestate = 0; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BrickBreakerBall ball = collision.gameObject.GetComponent<BrickBreakerBall>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
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
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
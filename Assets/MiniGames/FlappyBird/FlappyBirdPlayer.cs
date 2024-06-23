using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{
    private Vector3 direction;
    public float gravity= -9.8f;
    public float strength=5f;
  //  private Animator animator;


    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up*strength;
        //    animator.SetTrigger("happy");
        }
        if (Input.touchCount > 0)
        {
            Touch touch=Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;// animator.SetTrigger("happy");

            }

        }

        direction.y +=gravity*Time.deltaTime;
        transform.position += direction*Time.deltaTime;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstavle")
        {
            FindObjectOfType<FlappyBirdGameManager>().GameOver();
        }
       else if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<FlappyBirdGameManager>().IncreaseScore();
        }
    }
}

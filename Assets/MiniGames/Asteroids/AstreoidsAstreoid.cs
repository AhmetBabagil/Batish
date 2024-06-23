using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidsAstreoid : MonoBehaviour
{
    public Sprite[] sprites;
    private Animator animator;
    private CircleCollider2D circleCollider2d;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    public float size = 1.0f;
    public float minsize = 0.5f;
    public float maxsize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;

    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider2d = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];
        this.transform.eulerAngles=new Vector3(0,0,Random.value*360.0f);
        this.transform.localScale = Vector3.one * this.size;

        new Vector3(this.size, this.size, this.size);

        rigidbody2D.mass = this.size;
 
    }
    public void SetTrajectory(Vector2 direction)
    {
        rigidbody2D.AddForce(direction * this.speed);
        Destroy(this.gameObject,this.maxLifeTime);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstavle")
        {
            if ((this.size * 0.5) >= this.minsize)
            {
                animator.SetTrigger("exploit");
               

                CreateSplit();
                CreateSplit();
            }
           
            animator.SetTrigger("exploit");
          
        }
    }
    public void DestroyAstreoid()
    {
        FindObjectOfType<AstreoidsGameManager>().AstreoidDestroyed(this);
        Destroy(this.gameObject);
    }
    private void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        AstreoidsAstreoid half = Instantiate(this, position, this.transform.
            rotation); half.size = this.size * 0.5f; half.SetTrajectory(
                Random.insideUnitCircle.normalized*10.0f);
    }
}

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class DinoPlayer : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;

    public Animator batishanimator;

    [Header("SFX")]
    [SerializeField] private AudioClip dinojump;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

   
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * jumpForce;
                batishanimator.SetTrigger("happy");
                SoundManager.instance.PlaySound(dinojump);
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstavle"))
        {
            FindObjectOfType<DinoGameManager>().GameOver();
        }
    }

}
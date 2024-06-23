using UnityEngine;

[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(PacmanMovement))]
public class PacmanGhost : MonoBehaviour
{
    public PacmanMovement movement { get; private set; }
    public PacmanGhostHome home { get; private set; }
    public PacmanGhostScatter scatter { get; private set; }
    public PacmanGhostChase chase { get; private set; }
    public PacmanGhostFrightened frightened { get; private set; }
    public PacmanGhostBehaviour initialBehavior;
    public Transform target;
    public int points = 200;

    private void Awake()
    {
        movement = GetComponent<PacmanMovement>();
        home = GetComponent<PacmanGhostHome>();
        scatter = GetComponent<PacmanGhostScatter>();
        chase = GetComponent<PacmanGhostChase>();
        frightened = GetComponent<PacmanGhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehavior)
        {
            home.Disable();
        }

        if (initialBehavior != null)
        {
            initialBehavior.Enable();
        }
    }

    public void SetPosition(Vector3 position)
    {
        // Keep the z-position the same since it determines draw depth
        position.z = transform.position.z;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                FindObjectOfType<PacmanGameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<PacmanGameManager>().PacmanEaten();
            }
        }
    }

}

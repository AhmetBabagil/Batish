using UnityEngine;

[RequireComponent(typeof(PacmanGhost))]
public abstract class PacmanGhostBehaviour : MonoBehaviour
{
    public PacmanGhost ghost { get; private set; }
    public float duration;

    private void Awake()
    {
        ghost = GetComponent<PacmanGhost>();
    }

    public void Enable()
    {
        Enable(duration);
    }

    public virtual void Enable(float duration)
    {
        enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }

    public virtual void Disable()
    {
        enabled = false;

        CancelInvoke();
    }

}
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BrickBreakerResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<BrickBreakerGameManager>().Miss();
    }

}
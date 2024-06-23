using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdsBrick : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3f;
    [SerializeField] private float _damageTreshHold = 0.2f;
    [SerializeField] private GameObject _brickDeathParticle;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void DamageBrick(float damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
     //   AngryBirdsGameManager.instance.RemoveBaddie(this);

        Instantiate(_brickDeathParticle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude;

        if (impactVelocity > _damageTreshHold)
        {
            DamageBrick(impactVelocity);
        }

    }
}

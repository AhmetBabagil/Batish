using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdsBaddie : MonoBehaviour
{
    [SerializeField] private float _maxHealth=3f;
    [SerializeField] private float _damageTreshHold=0.2f;
    [SerializeField] private GameObject _baddieDeathParticle;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void DamageBaddie(float damageAmount)
    {
        _currentHealth-= damageAmount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AngryBirdsGameManager.instance.RemoveBaddie(this);
      
        Instantiate(_baddieDeathParticle, transform.position, Quaternion.identity);
      
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactVelocity = collision.relativeVelocity.magnitude; 
  
        if(impactVelocity > _damageTreshHold)
        {
            DamageBaddie(impactVelocity);
        }
    
    }
}

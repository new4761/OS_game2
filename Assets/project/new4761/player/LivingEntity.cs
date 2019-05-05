using UnityEngine;
using System.Collections;
using Mirror;
public class LivingEntity : NetworkBehaviour, IDamageable
{

    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, Collision hit)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
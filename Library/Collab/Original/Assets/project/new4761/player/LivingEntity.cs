using UnityEngine;
using System.Collections;
using Mirror;
public class LivingEntity : NetworkBehaviour, IDamageable
{

    public float startingHealth;
    public bool canDestory;


    [SyncVar]
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, Collision hit)
    {
        if (canDestory==true) {
            health -= damage;

            if (health <= 0 && !dead)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        DestroySelf();
    }
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

    // ServerCallback because we don't want a warning if OnTriggerEnter is
    // called on the client
    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        NetworkServer.Destroy(gameObject);
    }
}
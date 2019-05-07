using UnityEngine;
using System.Collections;
using Mirror;
public class LivingEntity : NetworkBehaviour, IDamageable
{

    public float startingHealth;
    public bool canDestory;
    protected float health;
    protected bool dead;
    protected float Shield;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
        Shield = 0;
    }

    public void TakeHit(float damage, Collision hit)
    {
        if (Shield != 0)
        {
            Shield -= damage;
        }
          else if (canDestory==true)
          {                          
             health -= damage;
                if (health <= 0 && !dead)
                {
                    Die();
                }
          }
    }
    public void uphealth()
    {
        health += 1;
        Debug.Log(health);
    }
    public void addShield()
    {
        Shield += 2;
        Debug.Log(Shield);
    }
    protected virtual void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
}
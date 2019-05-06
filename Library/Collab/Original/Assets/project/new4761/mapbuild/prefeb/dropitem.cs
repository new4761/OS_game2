using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropitem : LivingEntity
{
    public GameObject item;

    protected override void Die()
    {
        dead = true;
        Debug.Log(transform.position);
        GameObject teset = Instantiate(item, transform.position + Vector3.up * 0.5f, Quaternion.identity) ;
        GameObject.Destroy(gameObject);

    }
}

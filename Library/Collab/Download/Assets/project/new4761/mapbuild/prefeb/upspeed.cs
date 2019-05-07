using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class upspeed : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        playertank damageableObject = collision.collider.GetComponent<playertank>();
        damageableObject.agent.speed += 2;
        Debug.Log(damageableObject.agent.speed);
        DestroySelf();
    }
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
    void OnTriggerEnter(Collider co)
    {
        NetworkServer.Destroy(gameObject);
    }

}

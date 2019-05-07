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
     //   DestroySelf();
        NetworkServer.Destroy(gameObject);
        //GameObject.Destroy(gameObject);
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

﻿
using UnityEngine;
using Mirror;
public class uphp : NetworkBehaviour
{
    //void OnCollisionEnter(Collision collision)
    //{
    //    playertank damageableObject = collision.collider.GetComponent<playertank>();
    //    damageableObject.uphealth();
    //    NetworkServer.Destroy(gameObject);
    //}
    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        playertank damageableObject = co.GetComponent<playertank>();
        damageableObject.uphealth();
        DestroySelf();

    }
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

}

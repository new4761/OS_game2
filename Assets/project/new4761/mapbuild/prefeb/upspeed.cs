using UnityEngine;
using Mirror;

public class upspeed : NetworkBehaviour
{
    //void OnCollisionEnter(Collision collision)
    //{
    //    playertank damageableObject = collision.collider.GetComponent<playertank>();
    //    damageableObject.agent.speed += 2;
    //    Debug.Log(damageableObject.agent.speed);
    //    NetworkServer.Destroy(gameObject);
    //}


    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        playertank damageableObject = co.GetComponent<playertank>();
        damageableObject.agent.speed += 2;
        DestroySelf();

    }
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

}


using UnityEngine;
using Mirror;
public class getShield : NetworkBehaviour
{
    [ServerCallback]
    void OnTriggerEnter(Collider co)
    {
        playertank damageableObject = co.GetComponent<playertank>();
        damageableObject.addShield();
        DestroySelf();

    }
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    playertank damageableObject = collision.collider.GetComponent<playertank>();
    //    damageableObject.addShield();
    //    NetworkServer.Destroy(gameObject);
    //}
}

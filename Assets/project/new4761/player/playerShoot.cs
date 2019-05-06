using UnityEngine;
using System.Collections;
using Mirror;

    public class playerShoot : NetworkBehaviour
    {
    public float destroyAfter = 5;
    public Rigidbody rigidBody;
    public float force = 1000;
    public int Dm = 1;
    private bool hasEntered;


    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    // set velocity for server and client. this way we don't have to sync the
    // position, because both the server and the client simulate it.
    void Start()
    {
        rigidBody.AddForce(transform.forward * force);
    }
    [Server]
    void OnCollisionEnter(Collision collision)
    {
        // DestroySelf();
        DestroySelf();
        if (hasEntered==false)
        {
            hasEntered = true;
       
            IDamageable damageableObject = collision.collider.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                if (hasEntered == true)
                {

                    damageableObject.TakeHit(Dm, collision);

                    hasEntered = false;
                }

            }


        }
        
        
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

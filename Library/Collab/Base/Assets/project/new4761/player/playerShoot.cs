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

    // set velocity for server and client. this way we don't have to sy nc the
    // position, because both the server and the client simulate it.
    void Start()
    {
        hasEntered = false;
        rigidBody.AddForce(transform.forward * force);
    }
    void OnCollisionEnter(Collision collision)
    {
        // DestroySelf();
        DestroySelf();
        if (hasEntered==false)
        {DestroySelf();
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
    
    //void OnHitObject(Collision hit)
    //{
    //    IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
    //    if (damageableObject != null)
    //    {
    //        damageableObject.TakeHit(Dm, hit);
    //    }
     
    //    hasEntered = false;
    //}
    // destroy for everyone on the server
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

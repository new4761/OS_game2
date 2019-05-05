using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class playertank : LivingEntity
{
    [Header("Components")]
    public NavMeshAgent agent;
    //    public Animator animator;

    [Header("Movement")]
   // public float rotationSpeed = 100;
    public int movespeed = 10;
    [Header("Firing")]
    public KeyCode shootKey = KeyCode.Space;
    public GameObject projectilePrefab;
    public Transform projectileMount;

    [Header("PlayerStart")]
    Camera viewCamera;

  //  public int startHP;
    //public string playerName;
    //public int playerSlot;

    //private int curtHP ;
    //private int curtDM ;
    //private int curtSpeed ;
    private bool curtSheild ;
    private bool isDEAD;

   //  void Start()
   //wa {
      //  curtHP = startingHealth;
    // curtDM = startDM;
   //  curtSpeed = movespeed;
    // curtSheild = false;
   //     isDEAD = false;
  //  }
    void Update()
    {
        if (!isLocalPlayer) return;

        //Vector3 diretion;
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if ((moveHorizontal != 0 || moveVertical != 0 )&& (moveHorizontal == 0 || moveVertical == 0)) {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.rotation = Quaternion.LookRotation(movement);


            transform.Translate(movement * movespeed * Time.deltaTime, Space.World);


        }
        // shoot
        if (Input.GetKeyDown(shootKey))
        {
            CmdFire();
        }
    }
 

    // this is called on the server
    [Command]
    void CmdFire()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
        RpcOnFire();
    }

    // this is called on the tank that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
       // animator.SetTrigger("Shoot");
    }
}


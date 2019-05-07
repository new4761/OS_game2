
using UnityEngine;
using Mirror;
public class dropitem : LivingEntity
{
    public GameObject item1;
    public GameObject item2;
    protected override void Die()
    {
        dead = true;
        Debug.Log(transform.position);

     
        GameObject teset = Instantiate(item1, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        NetworkServer.Spawn(teset);
        NetworkServer.Destroy(gameObject);
        //  GameObject.Destroy(gameObject);
    }
}

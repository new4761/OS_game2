
using UnityEngine;
using Mirror;

public class dropitem : LivingEntity
{
    
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    protected override void Die()
    {
        
        dead = true;
       // Debug.Log(transform.position);
        System.Random rd = new System.Random();
        int rditem= rd.Next(1, 4);

        Dropitem(rditem);
        NetworkServer.Destroy(gameObject);
    }



    protected override void Dropitem(int rditem)
    {
        if (rditem == 1)
        {
            GameObject teset = Instantiate(item1, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            NetworkServer.Spawn(teset);
        }
        else if (rditem == 2)
        {
            GameObject teset = Instantiate(item2, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            NetworkServer.Spawn(teset);
        }
        else
        {
            GameObject teset = Instantiate(item3, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            NetworkServer.Spawn(teset);
        }
    }
}

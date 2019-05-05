using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapcreate : MonoBehaviour
{
    public Transform titlePrefab;
    public Transform wallPrefab;
    public Vector2 mapsize;
    [Range(0, 1)]
    public float outline;

    private void Start()
    {
        GenMap();   
    }
    public void GenMap()
    {
      

        string holdername = "Map gened";
        string wallholdername = "Wall gened";
        if (transform.Find(holdername))
        {
            DestroyImmediate(transform.Find(holdername).gameObject);
            DestroyImmediate(transform.Find(wallholdername).gameObject);
        }
        Transform mapholder = new GameObject(holdername).transform;
        Transform wallmapholder = new GameObject(wallholdername).transform;
        mapholder.parent = transform;
        wallmapholder.parent = transform;
        for (int x = 0; x < mapsize.x; x++)

        {
            for (int y = 0; y < mapsize.y; y++)
            {

                Vector3 tilepostion = new Vector3(-mapsize.x / 2 + 0.5f + x, 0, -mapsize.y / 2 + 0.5f + y);
                if ((x == 0 || y == 0) || (x == mapsize.x - 1 || y == mapsize.y - 1))
                {
                    Transform newWalltile = Instantiate(wallPrefab, tilepostion +Vector3.up*0.8f, Quaternion.identity) as Transform;
                    newWalltile.localScale = Vector3.one * (1 - outline);
                    newWalltile.parent = wallmapholder;
                }
                Transform newtile = Instantiate(titlePrefab, tilepostion, Quaternion.Euler(Vector3.right * 90)) as Transform;
               // Transform newWalltile = Instantiate(wallPrefab, tilepostion, Quaternion.identity) as Transform;
                newtile.localScale = Vector3.one * (1 - outline);
                newtile.parent = mapholder;
            }


        }

    }
   
}
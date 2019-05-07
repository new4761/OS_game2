using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Mapcreate : NetworkBehaviour
{
    public GameObject titlePrefab;
    public GameObject wallPrefab;
    public GameObject obj_dropItem;
    public GameObject obj_hard;
    public GameObject obj_easy;
    public int maxitem;
    public int itemrange;

    public Vector2 mapsize;
    [Range(0, 1)]
    public float outline;



    private bool isitem;
    private int coutitem;
    private int lastx = 0, lasty = 0;
    private void Start()
    {
        GenMap();   
    }
    public void GenMap()
    {
      

        string holdername = "Map gened";
        string wallholdername = "Wall gened";
        string obj_dropItem_st = "obj_dropItem";
       string obj_hard_st = "obj_hard";
        string obj_easy_st = "obj_easy";
  

        
        GameObject mapholder = new GameObject(holdername);
        GameObject wallmapholder = new GameObject(wallholdername);
        GameObject obj_easy_holder = new GameObject(obj_easy_st);
        GameObject obj_drop_holder = new GameObject(obj_dropItem_st);
        GameObject obj_hard_holder = new GameObject(obj_hard_st);

      // mapholder.parent = transform;
       // wallmapholder.parent = transform;
       // obj_easy_holder.parent = transform;
       // obj_drop_holder.parent = transform;
       // obj_hard_holder.parent = transform;
        for (int x = 0; x < mapsize.x; x++)

        {
            for (int y = 0; y < mapsize.y; y++)
            {

                Vector3 tilepostion = new Vector3(-mapsize.x / 2 + 0.5f + x, 0, -mapsize.y / 2 + 0.5f + y);
                if (((x == 0 || y == 0) || (x == mapsize.x - 1 || y == mapsize.y - 1)) || ((x > 0 && y > 0) && (x % 2 == 0 && y % 2 == 0)))
                {
                    GameObject newWalltile = Instantiate(wallPrefab, tilepostion + Vector3.up * 0.5f, Quaternion.identity);
                  //  GameObject newWalltile = Instantiate(wallPrefab, tilepostion + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                  //  newWalltile.localScale = Vector3.one * (1 - outline);
                    NetworkServer.Spawn(newWalltile);
                    //newWalltile.parent = wallmapholder;
                }
                else if (((x > 3 && x < mapsize.x - 4) || (y > 3 && y < mapsize.y-4)) ||( (x>=2&&y>=2)&&( x <= mapsize.x-3 && y  <= mapsize.y - 3)))
                {
                    isitem = (Random.value > 0.5f);
                   


                    if ((maxitem > coutitem && isitem)&&((x> lastx+ itemrange || y> lasty+ itemrange)))
                    {
                        GameObject obj_drop_cretae = Instantiate(obj_dropItem, tilepostion + Vector3.up * 0.5f, Quaternion.identity);
                        //   Transform obj_drop_cretae = Instantiate(obj_dropItem, tilepostion + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                        //  obj_drop_cretae.localScale = Vector3.one * (1 - outline);
                        //   obj_drop_cretae.parent = obj_drop_holder;
                        NetworkServer.Spawn(obj_drop_cretae);
                        coutitem++;
                        lastx = x;
                        lasty = y;
                    }
                    else
                    {
                        if (x%2==0&&((y > 3 && y < mapsize.y - 4)))
                        {
                            GameObject obj_hard_create = Instantiate(obj_hard, tilepostion + Vector3.up * 0.5f, Quaternion.identity);
                            NetworkServer.Spawn(obj_hard_create);
                            // Transform obj_hard_create = Instantiate(obj_hard, tilepostion + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                            //j_hard_create.localScale = Vector3.one * (1 - outline);
                            // obj_hard_create.parent = obj_hard_holder;

                        }
                        else
                        {
                            GameObject obj_easy_create = Instantiate(obj_easy, tilepostion + Vector3.up * 0.5f, Quaternion.identity);
                            NetworkServer.Spawn(obj_easy_create);
                            //Transform obj_easy_create = Instantiate(obj_easy, tilepostion + Vector3.up * 0.5f, Quaternion.identity) as Transform;
                            //  obj_easy_create.localScale = Vector3.one * (1 - outline);
                            //   obj_easy_create.parent = obj_easy_holder;
                        }
                    }

                }

                GameObject newtile = Instantiate(titlePrefab, tilepostion + Vector3.up * 0.5f, Quaternion.identity);
                NetworkServer.Spawn(newtile);
              //  Transform newtile = Instantiate(titlePrefab, tilepostion, Quaternion.Euler(Vector3.right * 90)) as Transform;
               // Transform newWalltile = Instantiate(wallPrefab, tilepostion, Quaternion.identity) as Transform;
             //  newtile.localScale = Vector3.one * (1 - outline);
             //   newtile.parent = mapholder;
            }

           
        }
        Debug.Log(coutitem);
    }
    
}
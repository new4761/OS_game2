using System;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Mynetworkmanger : NetworkManager
{


    public Transform[] spawnP;

    public GameObject player1obj;
    public GameObject player2obj;
    public GameObject player3obj;
    public GameObject player4obj;

    public GameObject map;

    public GameObject hud;

    public InputField playername;
    public InputField ipaddress;
    public InputField port;
    

    public Button host;
    public Button join;


    private int Cp;


    public override void Start()
    {
        // headless mode? then start the server
        // can't do this in Awake because Awake is for initialization.
        // some transports might not be ready until Start.
        //
        host.onClick.AddListener(hostClick);
        join.onClick.AddListener(joinClick);
        // (tick rate is applied in StartServer!)
        if (isHeadless && startOnHeadless)
        {
            StartServer();
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn, AddPlayerMessage extraMessage)
    {
        // add player at correct spawn position
     //   Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject playertank = Instantiate(player1obj, spawnP[Cp].position, spawnP[Cp].rotation);
        playertank.GetComponent<playertank>().playerName = playername.text;
        NetworkServer.AddPlayerForConnection(conn, playertank);
        Cp++;
        // spawn ball if two players

    }
    public void hostClick() {
        hud.gameObject.SetActive(false);    

        StartHost();
 

    }
    public void joinClick()
    {
        hud.gameObject.SetActive(false);
        networkAddress =ipaddress.text; 
        StartClient();
  
    }
    public override void OnStartServer()
    {

        GameObject mapcretea = Instantiate(map, transform.position, transform.rotation);
        NetworkServer.Spawn(mapcretea);
    }

    // Update is called once per frame

}

using System;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Mynetworkmanger : NetworkManager
{
    public Transform player1Spawn;
    public Transform player2Spawn;
    public Transform player3Spawn;
    public Transform player4Spawn;

    public GameObject player1obj;
    public GameObject player2obj;
    public GameObject player3obj;
    public GameObject player4obj;

    public GameObject map;


    public InputField playername;
    public InputField ipaddress;
    public InputField port;


    public Button host;
    public Button join;
    // Start is called before the first frame update
    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        host.onClick.AddListener(hostClick);
        join.onClick.AddListener(joinClick);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, AddPlayerMessage extraMessage)
    {
        // add player at correct spawn position
     //   Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject playertank = Instantiate(player1obj, player1Spawn.position, player1Spawn.rotation);
        playertank.GetComponent<playertank>().playerName = playername.text;
        NetworkServer.AddPlayerForConnection(conn, playertank);

        // spawn ball if two players

    }
    public void hostClick() {
    
        StartHost();
        GameObject mapcretea = Instantiate(map, transform.position, transform.rotation);
        NetworkServer.Spawn(mapcretea);

    }
    public void joinClick()
    {
     
        networkAddress =ipaddress.text; 
        StartClient();
  
    }

    // Update is called once per frame

}

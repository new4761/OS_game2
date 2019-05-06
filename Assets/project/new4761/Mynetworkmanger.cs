using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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
    // Start is called before the first frame update

    public override void OnServerAddPlayer(NetworkConnection conn, AddPlayerMessage extraMessage)
    {
        // add player at correct spawn position
     //   Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        GameObject playertank = Instantiate(player1obj, player1Spawn.position, player1Spawn.rotation);
        NetworkServer.AddPlayerForConnection(conn, playertank);

        // spawn ball if two players

    }

    // Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class InstantiatePlayers : MonoBehaviour
{
    public GameObject playerPrefab; // The prefab for the player character
    public List<Transform> spawnPoints; // A list of all the spawn points in the scene

    // Start is called before the first frame update
    void Start()
    {
        // Select a random spawn point from the list
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate the player at the selected spawn point
        
        GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate(this.playerPrefab.name, spawnPoint.position, Quaternion.identity, 0);
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
        myPlayer.GetComponentInChildren<PlayerMovement>().ID = PhotonNetwork.LocalPlayer.ActorNumber;
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
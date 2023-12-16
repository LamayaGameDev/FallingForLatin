using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
 
    public float Delay = 1;

    private GameObject myPlayer;
    public Transform startSpawn;

    void Start()
    {
      
        StartCoroutine(DelayInstantiation());

    }

    IEnumerator DelayInstantiation()
    {
        yield return new WaitForSeconds(1f);

        GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate(playerPrefab.name, startSpawn.position, Quaternion.identity, 0);
        //yield return new WaitForSeconds(1f);



    
        
    }



}

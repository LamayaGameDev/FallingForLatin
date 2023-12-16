using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class winnerCall : MonoBehaviour
{
    public int totalPlayerCount;
    public int remainingPlayerCount;
    public Photon.Realtime.Room currentRoom;
    public Transform podiumSpawnpoint;
    public Text timeTxt;
    PhotonView view;
    public static winnerCall Instance;
    public GameObject questionManager;
    public GameObject[] questionGameObjects;
    public GameObject questionCaller;
    public GameObject platformA;
    public GameObject platformB;
    public GameObject platformC;
    public GameObject platformD;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        numberPlayers();
        remainingPlayerCount = totalPlayerCount;
        Instance= this;
        remainingPlayerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    
    public void CheckWinner()
    {
        if (remainingPlayerCount == 1)
        {
            Debug.Log("We have a winner");
            //Time.timeScale
        }
    }
   



    public Text remainingPlayerText;

    // Update is called once per frame
    void Update()
    {
        numberPlayers();
        if (PhotonNetwork.InRoom)
        {
            //if (/*PhotonNetwork.CurrentRoom.PlayerCount*/remainingPlayerCount == 1)
            //{
            //DisableQuestionObjects();
            //questionManager.SetActive(false);
            //questionCaller.SetActive(false);
            int remainingPlayers = 0;
            PlayerMovement playerMovement;
            Photon.Realtime.Player winningPlayer = null;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                if (!PlayerMovement.playerList[player.ActorNumber].dead)
                {
                    remainingPlayers++;
                    playerMovement = PlayerMovement.playerList[player.ActorNumber];
                    winningPlayer = player;
                }
                  

            }
            if (remainingPlayers == 1) {

                remainingPlayerText.text = winningPlayer.NickName + " has won!";
                /*platformA.SetActive(true);
                platformB.SetActive(true);
                platformC.SetActive(true);
                platformD.SetActive(true);
                timeTxt.gameObject.SetActive(false);*/
                PhotonNetwork.LoadLevel("Win");

            }

            //}
        }
    }
   
    void DisableQuestionObjects()
    {
        for (int i = 0; i < questionGameObjects.Length; i++)
        {
            questionGameObjects[i].SetActive(false);
        }
    }

    public void UpdateRemainingPlayers()
    {
        remainingPlayerCount--;
    }

      

    public void numberPlayers()
    {
        if (PhotonNetwork.IsConnected)
        {
            currentRoom = PhotonNetwork.CurrentRoom;
            totalPlayerCount = currentRoom.PlayerCount;
            Debug.Log("Number of players in room: " + totalPlayerCount);
        }
    }

   
    




}

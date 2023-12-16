using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine;


public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField roomInput;
    //public InputField joinInput;
    public InputField NameInput;
    public AudioSource audioSource;
    public AudioClip clickSound;


    private void Start()
    {

    }

    public void SetName()
    {


        // Set the player's name in the Photon Network
        PhotonNetwork.NickName = NameInput.text;
       
        Debug.Log("Name changed!");
    }

    public void CreateRoom()
    {
        Debug.Log("Creating...");
        audioSource.PlayOneShot(clickSound);
        PhotonNetwork.CreateRoom(roomInput.text);
    }

    public void JoinRoom()
    {
        Debug.Log("Joining room: " + roomInput.text);
        audioSource.PlayOneShot(clickSound);
        PhotonNetwork.JoinRoom(roomInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("On Join...");
        PhotonNetwork.LoadLevel("Lobby");
    }
}

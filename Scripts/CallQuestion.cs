using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CallQuestion : MonoBehaviourPunCallbacks
{
    public QuestionManager questionManager;

    private void Start()
    {
        PhotonNetwork.AddCallbackTarget(this);
        
        //AskRandomQuestion();
    }

    private void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        int randomPlayerIndex = Random.Range(0, PhotonNetwork.PlayerList.Length);
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[randomPlayerIndex]);
    }



    
    void Update()
    {
        if (questionManager.questionAsked == false)
        {
            AskRandomQuestion();
        }
    }

    public void AskRandomQuestion()
    {
        int questionNumber = Random.Range(0, questionManager.Questions.Length);
        PhotonView photonView = this.GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
           
            photonView.RPC("SyncQuestion", RpcTarget.OthersBuffered, questionNumber);
            Debug.LogWarning("Question synced");
        }
        else
        {
            // Wait for the question to be synced
            return;
        }
        questionManager.AskQuestion(questionNumber);
    }

    [PunRPC]
    public void SyncQuestion(int questionNumber)
    {
        questionManager.AskQuestion(questionNumber);
        
    }
}

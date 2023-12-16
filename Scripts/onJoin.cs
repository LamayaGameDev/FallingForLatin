using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class onJoin : MonoBehaviour, IPunObservable
{
    public float timeLeft = 60f; // time left in seconds
    public Text text;
    PhotonView PV;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (text != null)
        {
            text.gameObject.SetActive(true);
        }
        StartCoroutine(DecreaseTime());
    }

    void Update()
    {
        if (text != null)
        {
            text.text = timeLeft.ToString();
        }
        if (timeLeft <= 0)
        {
            text.gameObject.SetActive(false);
            PhotonNetwork.LoadLevel("Game");
        }
    }

    IEnumerator DecreaseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        StartCoroutine(DecreaseTime());
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(timeLeft);
        }
        else
        {
            timeLeft = (float)stream.ReceiveNext();
        }
    }
}

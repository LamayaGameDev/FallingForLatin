using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class followPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    void LateUpdate()
    {
        if (view.IsMine)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
       
    }
}

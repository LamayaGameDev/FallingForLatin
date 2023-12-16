
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class camFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 1f;
    public Vector3 offset;

    void Update()
    {
        transform.position = target.position;
    }
}
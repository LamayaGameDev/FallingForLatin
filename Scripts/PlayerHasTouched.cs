using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerHasTouched : MonoBehaviour
{
    public bool hasTouched = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        hasTouched = true;
    }

    public bool GetHasTouched()
    {
        return hasTouched;
    }

    public void SetHasTouched(bool value)
    {
        hasTouched = value;
    }
}
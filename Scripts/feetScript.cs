using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class feetScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            playerMovement.Death();
        }
    }
}

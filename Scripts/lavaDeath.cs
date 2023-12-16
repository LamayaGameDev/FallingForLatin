using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaDeath : MonoBehaviour
{
    public Transform deathPoint;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("You hit the lava");
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

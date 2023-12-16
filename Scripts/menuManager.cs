using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject controlsPanel;
    public AudioSource audioSource;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadControls()
    {
        controlsPanel.SetActive(true);
        audioSource.PlayOneShot(clickSound);
        mainPanel.SetActive(false);
    }
    public void loadMenu()
    {
        controlsPanel.SetActive(false);
        audioSource.PlayOneShot(clickSound);
        mainPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

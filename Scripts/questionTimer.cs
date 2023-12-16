using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class questionTimer : MonoBehaviour
{
    public float maxTime = 30f;
    public float timeLeft;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 30f;
         timeText.text = 30f.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft -= Time.deltaTime;
        timeText.text = ((int)timeLeft).ToString();
        if (timeLeft <= 0)
        {
            timeText.gameObject.SetActive(false);
        }

    }
    public void SetTime()
    {
        timeLeft = 30;
        timeText.gameObject.SetActive(true);
        timeText.text = ((int)timeLeft).ToString();

    }
}

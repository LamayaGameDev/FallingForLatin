using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class QuestionManager : MonoBehaviour
{
    public GameObject[] Platforms;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject QuestionsContainer;
    public question[] Questions; 
    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;
    public GameObject question5;
    public int correctAnswer; // 1-4
    //question timer class
    public questionTimer questionTime;

    public int previousQuestion = 0;
    public bool questionAsked;
    void Awake()
    {

  
        Questions = QuestionsContainer.GetComponentsInChildren<question>();
        for (int i = 0; i < Questions.Length; i++)
        {
            Questions[i].gameObject.SetActive(false);
        }
        Debug.Log(Questions.Length);
    }
   
    public IEnumerator ChangePlatform(int qNo)
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            Platforms[i].SetActive(true);
        }
        questionTime.SetTime();
        yield return new WaitForSeconds(30f);
        for (int i = 0; i < Platforms.Length; i++)
        {
            Platforms[i].SetActive(false);

        }
        Platforms[correctAnswer - 1].SetActive(true);

        yield return new WaitForSeconds(5f);
        questionAsked = false;
        Questions[qNo].gameObject.SetActive(false);


    }


    
    
    public void AskQuestion(int questionNumber)
    {
        int qNo = questionNumber;
        // Disable all questions
        questionAsked = true;
        Questions[previousQuestion].gameObject.SetActive(false);
        previousQuestion= qNo;

        while (Questions[qNo].hasAsked == true)
        {
            qNo++;
            if (qNo == Questions.Length)
            {
                qNo = 0;
            }
            if (questionNumber == qNo)
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    Questions[i].hasAsked = false;
                    Questions[i].gameObject.SetActive(false);

                }
                //qNo = previousQuestion;

                break;
            }
        }
        Questions[qNo].gameObject.SetActive(true);
        correctAnswer = Questions[qNo].correctAnswer;
        Questions[qNo].hasAsked = true;
        StartCoroutine(ChangePlatform(qNo));
        

    }
}
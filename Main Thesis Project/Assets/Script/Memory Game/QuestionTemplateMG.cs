using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTemplateMG 
{
    public float Qno;
    public string Question;
    public float QTime;

    public string CorrectAnswer;


    public QuestionTemplateMG(int newQno, string newQuestion, string newCorrectAnswer, float newQtime)
    {
        Qno = newQno;
        Question = newQuestion;
        QTime = newQtime;
        CorrectAnswer = newCorrectAnswer;

    }

}

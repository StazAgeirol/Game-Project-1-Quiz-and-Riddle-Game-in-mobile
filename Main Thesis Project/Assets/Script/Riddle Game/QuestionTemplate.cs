using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuestionTemplate   {

	public float Qno;
	public string Question;
    public string hintshow;

    public string CorrectAnswer;
    

    public QuestionTemplate(int newQno, string newQuestion,  string newCorrectAnswer, string hint)
	{
		Qno = newQno;
		Question = newQuestion;
        hintshow = hint;
		CorrectAnswer = newCorrectAnswer;
        
	}
	
}

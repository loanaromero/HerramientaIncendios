using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript1 : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager1 quizManager1;

    public AudioSource audioSourceRespuestas;
    public AudioClip clipAcierto;
    public AudioClip clipFallo;

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    public bool ponerBlanco = false;

    private void Update()
    {
        if (ponerBlanco)
        {
            btn1.GetComponent<Image>().color = Color.white;
            btn2.GetComponent<Image>().color = Color.white;
            btn3.GetComponent<Image>().color = Color.white;
            ponerBlanco = false;
        }
    }
    public void Answer()
    {
        GetComponent<Image>().color = Color.white;
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager1.correct();
            GetComponent<Image>().color = Color.green;
            audioSourceRespuestas.PlayOneShot(clipAcierto);
            quizManager1.InfoTxtEdit.text = "¡GENIAL! AVANZAS 3 CASILLEROS";
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager1.wrong();
            GetComponent<Image>().color = Color.red;
            audioSourceRespuestas.PlayOneShot(clipFallo);
            Handheld.Vibrate();
            quizManager1.InfoTxtEdit.text = "¡QUÉ PENA! AVANZAS 1 CASILLERO";
        }
    }
}

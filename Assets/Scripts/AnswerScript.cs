using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
	public QuizManager quizManager;

    public AudioSource audioSourceRespuestas;
    public AudioClip clipAcierto;
    public AudioClip clipFallo;

    public void Answer()
    {
        GetComponent<Image>().color = Color.white;
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
            StartCoroutine(CambiarColorVerdeBtn());
            audioSourceRespuestas.PlayOneShot(clipAcierto);
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
            StartCoroutine(CambiarColorRojoBtn());

            audioSourceRespuestas.PlayOneShot(clipFallo);
            Handheld.Vibrate();
        }
    }

    IEnumerator CambiarColorVerdeBtn()
    {
        GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(1.2f);
        GetComponent<Image>().color = Color.white;
    }
    IEnumerator CambiarColorRojoBtn()
    {
        GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(1.2f);
        GetComponent<Image>().color = Color.white;
    }
}

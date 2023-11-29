using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Panel;
    public GameObject Puntaje;
    public GameObject boton;
    public GameObject Tiempo;

    public Text Questiontxt;
    public Text ScoreTxt;
    public Text TimeTxt;


    int totalQuestions = 0;
    public int score;
    public int proxima;
    public float tiempoInicio = 50;


    public void Start()
    {
        TimeTxt.text = tiempoInicio.ToString();
        totalQuestions = QnA.Count;
        Puntaje.SetActive(false);
        generateQuestion();
        proxima = SceneManager.GetActiveScene().buildIndex + 2;
    }

    public void Update()
    {
        tiempoInicio -= Time.deltaTime;
        TimeTxt.text = Mathf.Round(tiempoInicio).ToString();

        if(tiempoInicio < 1)
        {
            GameOver();
        } 
    }

    public void GameOver()
    {
        Panel.SetActive(false);
        Puntaje.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
       /* if (score >= 10)
        {
            if (SceneManager.GetActiveScene().buildIndex<=6)
            {
                PlayerPrefs.SetInt("nivel", proxima);
                if (proxima > PlayerPrefs.GetInt("nivel"))
                {
                    PlayerPrefs.SetInt("nivel", proxima);
                    Debug.Log("ola");
                }
            }
            
        }*/
    }   

    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void correct()
    {
        Tiempo.SetActive(false);
        //contestas bn ;)
        score += 1;
        QnA.RemoveAt(currentQuestion);
        Invoke("desactivarBotones", 2f);
        Invoke("botonON", 2f);
        Invoke("generateQuestion", 2f);
    }

    public void wrong()
    {
        Tiempo.SetActive(false);
        //le pifias :(
        QnA.RemoveAt(currentQuestion);
        Invoke("desactivarBotones", 2f);
        Invoke("botonON", 2f);
        Invoke("generateQuestion", 2f);
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            Questiontxt.text = QnA[currentQuestion].Question;
            SetAnswers();
            //QnA.RemoveAt(currentQuestion);
        }
        else
        {
            GameOver();
        }
    }

    void botonON ()
    {
        Tiempo.SetActive(true);
        tiempoInicio = 50;
        boton.SetActive(true);
    }
  
    void desactivarBotones()
    {
        boton.SetActive(false);
    }
}

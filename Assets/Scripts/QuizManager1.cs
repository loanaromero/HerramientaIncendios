using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager1 : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject PanelInstrucciones;
    public GameObject Panel;
    public GameObject Puntaje;
    public GameObject boton;
    public GameObject Tiempo;
    public GameObject Reloj;

    public Text Questiontxt;
    public Text ScoreTxt;
    public Text TimeTxt;


    int totalQuestions = 0;
    public int score;
    public int proxima;
    public float tiempoInicio = 60;

    public bool empieza = false;

    public GameObject btnJugador;
    public Text InfoTxtEdit; //informacion sobre cuantos casilleros avanza
    public GameObject InfoText;
    public GameObject volverGeneral;

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
        if (empieza)
        {
            tiempoInicio -= Time.deltaTime;
            TimeTxt.text = Mathf.Round(tiempoInicio).ToString();
        }

        if(tiempoInicio < 1)
        {
            wrong();
        } 
    }
    
    public void GameOver()
    {
        volverGeneral.SetActive(true);
        empieza = false;
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
            }*/
            
    }
   
    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void correct()
    {
        InfoText.SetActive(true);
        btnJugador.SetActive(true);
        Tiempo.SetActive(false);
        Reloj.SetActive(false);
        //contestas bn ;)
        score += 1;
        QnA.RemoveAt(currentQuestion);
        //Invoke("desactivarBotones", 2f);
        //Invoke("botonON", 2f);
        //Invoke("generateQuestion", 2f);
    }

    public void wrong()
    {
        InfoText.SetActive(true);
        btnJugador.SetActive(true);
        Tiempo.SetActive(false);
        Reloj.SetActive(false);
        //le pifias :(
        QnA.RemoveAt(currentQuestion);
        //Invoke("desactivarBotones", 2f);
        //Invoke("botonON", 2f);
        //Invoke("generateQuestion", 2f);
    }

    public void nextPlayer()
    {
        FindObjectOfType<AnswerScript1>().ponerBlanco = true;
        Invoke("desactivarBotones", 0f);
        Invoke("botonON", 0f);
        Invoke("generateQuestion", 0f);
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript1>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript1>().isCorrect = true;
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
        Reloj.SetActive(true);
        btnJugador.SetActive(false);
        InfoText.SetActive(false);
        tiempoInicio = 60;
        boton.SetActive(true);
    }
  
    void desactivarBotones()
    {
        boton.SetActive(false);
    }

    public void Comenzar()
    {
        PanelInstrucciones.SetActive(false);
        Panel.SetActive(true);
        volverGeneral.SetActive(false);
        empieza = true;
    }
}

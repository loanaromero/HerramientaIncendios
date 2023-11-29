using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selector : MonoBehaviour
{
    public void simulador()
    {
        SceneManager.LoadScene("simuladorExtintor");

    }
    public void acciones()
    {
        SceneManager.LoadScene("Acciones");
    }
    public void trivia()
    {
        SceneManager.LoadScene("triviaCapacitacion");
    }

    public void volver()
    {
        SceneManager.LoadScene("selectorCapacitacion");
    }
}


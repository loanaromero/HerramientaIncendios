using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void pasar()
    {
        SceneManager.LoadScene("selectorCapacitacion");
    }

    public void volverMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void abrirTablero()
    {
        SceneManager.LoadScene("triviaTablero");
    }
}

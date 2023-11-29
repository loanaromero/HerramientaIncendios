using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class accionesManager : MonoBehaviour
{
    public GameObject fondo;

    public GameObject panelAccion1;
    public GameObject panelAccion2;

    public GameObject panelBotonesAccion1;
    public GameObject panelBotonesAccion2;

    //Paneles extintor
    public GameObject panelPantalla2;
    public GameObject panelPantalla3;
    public GameObject panelPantalla4;
    public GameObject panelPantalla5;
    public GameObject panelPantalla6;
    public GameObject panelFin;

    //Paneles bomberos
    public GameObject panelPantallaBomb1;
    public GameObject panelPantallaBomb2;
    public GameObject panelFinBomb;

    public GameObject btnExtintor;
    public GameObject btnBomberos;
    public GameObject btnEsperar;
    public GameObject btnBomberosIncorrecto;
    public GameObject btnEsperarIncorrecto;

    //Botones bomberos
    public GameObject btnCubrirRostro;
    public GameObject btnLlamarBomb;
    public GameObject btnLlamarBomb2;
    public GameObject btnLlamarBombIncorrecto;

    //Botones extintor
    public GameObject btnDistancia;
    public GameObject btnPalanca;
    public GameObject btnGatillo;
    public GameObject btnPalancaIncorrecto;
    public GameObject btnGatilloIncorrecto;

    public GameObject btnPalanca2;
    public GameObject btnGatillo2;
    public GameObject btnDisparo;
    public GameObject btnPalanca2Incorrecto;
    public GameObject btnDisparoIncorrecto;


    public GameObject btnAcercarse;
    public GameObject btnPalanca3;
    public GameObject btnDisparo2;
    public GameObject btnAcercarseIncorrecto;
    public GameObject btnDisparo2Incorrecto;

    public GameObject btnAcercarse2;
    public GameObject btnDisparo3;
    public GameObject btnDisparo4;
    public GameObject btnDisparo3Incorrecto;

    public int panelElegido;

    public GameObject panelGameOver;
    //Tiempo
    public GameObject Tiempo;
    public Text TimeTxt;
    public float tiempoInicio = 60;
    public bool comienzo = false;

    void Start()
    {
        panelElegido = Random.Range(1, 3);
        Debug.Log(panelElegido);
        if (panelElegido == 1)
        {
            panelAccion1.SetActive(true);
        }

        if (panelElegido == 2)
        {
            panelAccion2.SetActive(true);
        }
    }

    void Update()
    {
        if (comienzo)
        {
            tiempoInicio -= Time.deltaTime;
            TimeTxt.text = Mathf.Round(tiempoInicio).ToString();

            if (tiempoInicio < 1)
            {
                GameOver();
            }
        }
    }

    public void Comenzar()
    {
        comienzo = true;
        if (panelElegido == 1)
        {
            panelAccion1.SetActive(false);
            panelBotonesAccion1.SetActive(true);
        }

        if (panelElegido == 2)
        {
            panelAccion2.SetActive(false);
            panelBotonesAccion2.SetActive(true);
        }
    }

    //Primer pantalla EXTINTOR
    public void UsarExtintor()
    {
        btnExtintor.SetActive(false);
        btnBomberos.SetActive(false);
        btnEsperar.SetActive(false);
        btnBomberosIncorrecto.SetActive(false);
        btnEsperarIncorrecto.SetActive(false);
        panelPantalla2.SetActive(true);
        btnExtintor.SetActive(false);
        btnEsperarIncorrecto.SetActive(false);
        btnBomberosIncorrecto.SetActive(false);
    }

    public void LlamarBomberos()
    {
        btnExtintor.SetActive(false);
        btnBomberos.SetActive(false);
        btnEsperar.SetActive(false);
        Handheld.Vibrate();
        btnBomberos.SetActive(false);
        //Primer pantalla BOMBEROS
        panelPantallaBomb1.SetActive(true);
    }
    public void Esperar()
    {
        Handheld.Vibrate();
        btnEsperar.SetActive(false);
        btnEsperarIncorrecto.SetActive(true);
    }

    //Segunda pantalla EXTINTOR
    public void TomarDistancia()
    {
        panelPantalla2.SetActive(false);
        panelPantalla3.SetActive(true);
        //btnDistancia.SetActive(false);
        btnPalancaIncorrecto.SetActive(false);
        btnGatilloIncorrecto.SetActive(false);
    }

    public void ApretarPalanca()
    {
        Handheld.Vibrate();
        btnPalanca.SetActive(false);
        btnPalancaIncorrecto.SetActive(true);
    }
    public void LiberarGatillo()
    {
        Handheld.Vibrate();
        btnGatillo.SetActive(false);
        btnGatilloIncorrecto.SetActive(true);
    }

    //Tercera pantalla EXTINTOR
    public void ApretarPalanca2()
    {
        Handheld.Vibrate();
        btnPalanca2.SetActive(false);
        btnPalanca2Incorrecto.SetActive(true);
    }

    public void LiberarGatillo2()
    {
        panelPantalla3.SetActive(false);
        panelPantalla4.SetActive(true);
        //btnGatillo2.SetActive(false);
        btnPalanca2Incorrecto.SetActive(false);
        btnDisparoIncorrecto.SetActive(false);
    }

    public void DisparoFuego()
    {
        Handheld.Vibrate();
        btnDisparo.SetActive(false);
        btnDisparoIncorrecto.SetActive(true);
    }

    //Cuarta pantalla EXTINTOR
    public void Acercarse()
    {
        Handheld.Vibrate();
        btnAcercarse.SetActive(false);
        btnAcercarseIncorrecto.SetActive(true);
    }

    public void ApretarPalanca3()
    {
        panelPantalla4.SetActive(false);
        panelPantalla5.SetActive(true);
        //btnPalanca3.SetActive(false);
        btnAcercarseIncorrecto.SetActive(false);
        btnDisparo2Incorrecto.SetActive(false);
    }

    public void DisparoFuego2()
    {
        Handheld.Vibrate();
        btnDisparo2.SetActive(false);
        btnDisparo2Incorrecto.SetActive(true);
    }

    //Quinta pantalla EXTINTOR
    public void Acercarse2()
    {
        panelPantalla5.SetActive(false);
        panelPantalla6.SetActive(true);
        //btnAcercarse2.SetActive(false);
        btnDisparo3Incorrecto.SetActive(false);
    }
    public void DisparoFuego3()
    {
        Handheld.Vibrate();
        btnDisparo3.SetActive(false);
        btnDisparo3Incorrecto.SetActive(true);
    }

    //Sexta pantalla EXTINTOR
    public void DisparoFuego4()
    {
        panelPantalla6.SetActive(false);
        fondo.SetActive(false);
        panelFin.SetActive(true);
        //btnDisparo4.SetActive(false);
    }

    //Fin
    public void VolverCapacitaciones()
    {
        SceneManager.LoadScene("selectorCapacitacion");
    }

    //Segunda pantalla BOMBEROS
    public void CubrirRostro()
    {
        panelPantallaBomb1.SetActive(false);
        panelPantallaBomb2.SetActive(true);
    }

    //Tercera pantalla BOMBEROS
    public void LlamarBomberos2()
    {
        panelPantallaBomb2.SetActive(false);
        fondo.SetActive(false);
        panelFinBomb.SetActive(true);
    }

    public void GameOver()
    {
        panelAccion1.SetActive(false);
        panelAccion2.SetActive(false);
        panelBotonesAccion1.SetActive(false);
        panelBotonesAccion2.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("Acciones");
    }
}

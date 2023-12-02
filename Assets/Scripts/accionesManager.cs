using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class accionesManager : MonoBehaviour
{
    public GameObject fondo;
    public GameObject fondoA2;

    public GameObject panelAccion1;
    public GameObject panelAccion2;

    public GameObject panelBotonesAccion1;
    public GameObject panelBotonesAccion2;

    public GameObject volverGeneral;
    public GameObject volverA1;
    public GameObject volverA2;

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

    //Tiempo A1
    public GameObject TiempoObj;
    public Text TimeTxt;
    public float tiempoInicio = 60;
    public bool comienzo = false;


    //Paneles Alarma
    public GameObject panelPantallaAlarma1;
    public GameObject panelPantallaAlarma2;
    public GameObject panelPantallaAlarma3;
    public GameObject panelPantallaAlarma4;
    public GameObject panelAlarmaFin;

    public GameObject btnAlarma;
    public GameObject btnBomberosA2;
    public GameObject btnEsperarA2;
    public GameObject btnBomberosA2Incorrecto;
    public GameObject btnEsperarA2Incorrecto;

    //Botones Alarma
    public GameObject btnEvacuar;
    public GameObject btnEvacuarIncorrecto;
    public GameObject btnCerrarPuertas;
    public GameObject btnCerrarPuertasIncorrecto;
    public GameObject btnPuntoEncuentro;
    public GameObject btnPuntoEncuentroIncorrecto;
    public GameObject btnPuntoEncuentro2;
    public GameObject btnPuntoEncuentro2Incorrecto;

    //Paneles Extintor
    public GameObject panelA2Pantalla2;
    public GameObject panelA2Pantalla3;
    public GameObject panelA2Pantalla4;
    public GameObject panelA2Pantalla5;
    public GameObject panelA2Pantalla6;
    public GameObject panelA2Fin;

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
        TiempoObj.SetActive(true);
        if (panelElegido == 1)
        {
            panelAccion1.SetActive(false);
            volverGeneral.SetActive(false);
            volverA1.SetActive(true);
            panelBotonesAccion1.SetActive(true);
        }

        if (panelElegido == 2)
        {
            panelAccion2.SetActive(false);
            volverGeneral.SetActive(false);
            volverA2.SetActive(true);
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
    }

    public void LlamarBomberos()
    {
        btnExtintor.SetActive(false);
        btnBomberos.SetActive(false);
        btnEsperar.SetActive(false);
        Handheld.Vibrate();
        btnBomberos.SetActive(false);
        btnEsperarIncorrecto.SetActive(false);
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
        comienzo = false;
        TiempoObj.SetActive(false);
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
        comienzo = false;
        TiempoObj.SetActive(false);
        panelFinBomb.SetActive(true);
    }

    //PANTALLAS A2
    public void ActivarAlarma()
    {
        btnAlarma.SetActive(false);
        btnBomberosA2.SetActive(false);
        btnEsperarA2.SetActive(false);
        btnBomberosA2Incorrecto.SetActive(false);
        btnEsperarA2Incorrecto.SetActive(false);
        panelPantallaAlarma1.SetActive(true);
    }

    public void LlamarBomberosA2()
    {
        Handheld.Vibrate();
        btnBomberos.SetActive(false);
        btnBomberosA2Incorrecto.SetActive(true);
    }
    public void EsperarA2()
    {
        Handheld.Vibrate();
        btnEsperarA2.SetActive(false);
        btnEsperarA2Incorrecto.SetActive(true);
        Debug.Log("emtro y cambio");
    }

    //P1 Alarma
    public void Evacuar()
    {
        Handheld.Vibrate();
        btnEvacuar.SetActive(false);
        btnEvacuarIncorrecto.SetActive(true);
    }

    public void LlamarBomberosA2_1()
    {
        panelPantallaAlarma1.SetActive(false);
        panelPantallaAlarma2.SetActive(true);
        btnEvacuarIncorrecto.SetActive(false);
        btnCerrarPuertasIncorrecto.SetActive(false);
    }

    public void CerrarPuertas()
    {
        Handheld.Vibrate();
        btnCerrarPuertas.SetActive(false);
        btnCerrarPuertasIncorrecto.SetActive(true);
    }

    //P2 Alarma
    public void UsarExtintorA2()
    {
        panelPantallaAlarma2.SetActive(false);
        //Panel extintor
        /*.SetActive(true);*/
        btnEvacuarIncorrecto.SetActive(false);
        btnCerrarPuertasIncorrecto.SetActive(false);
    }

    public void PuntoEncuentro()
    {
        Handheld.Vibrate();
        btnPuntoEncuentro.SetActive(false);
        btnPuntoEncuentroIncorrecto.SetActive(true);
    }

    public void Evacuar2()
    {
        panelPantallaAlarma2.SetActive(false);
        panelPantallaAlarma3.SetActive(true);
        btnPuntoEncuentroIncorrecto.SetActive(false);
    }

    //P3 Alarma
    public void PuntoEncuentro2()
    {
        Handheld.Vibrate();
        btnPuntoEncuentro2.SetActive(false);
        btnPuntoEncuentro2Incorrecto.SetActive(true);
    }
    public void CerrarPuertas2()
    {
        panelPantallaAlarma3.SetActive(false);
        panelPantallaAlarma4.SetActive(true);
        btnPuntoEncuentro2Incorrecto.SetActive(false);
    }
    //P4 Alarma
    public void PuntoEncuentro3()
    {
        panelPantallaAlarma4.SetActive(false);
        fondoA2.SetActive(false);
        panelAlarmaFin.SetActive(true);
        comienzo = false;
        TiempoObj.SetActive(false);
    }

    public void GameOver()
    {
        volverGeneral.SetActive(true);
        panelAccion1.SetActive(false);
        panelAccion2.SetActive(false);
        panelBotonesAccion1.SetActive(false);
        panelBotonesAccion2.SetActive(false);
        panelGameOver.SetActive(true);
        TiempoObj.SetActive(false);
        comienzo = false;
    }

    public void Reintentar()
    {
        SceneManager.LoadScene("Acciones");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject muestraPierdes;

    // Update is called once per frame
    void Update()
    {
        if (SaludPersonaje.instance.vidas == 0)
        {
            Timer.instance.timerIsRunning = false;
            MuevePersonaje.instance.animator.SetBool("muerta", true);
            MuevePersonaje.instance.velocidad = 0;
            MuevePersonaje.instance.fuerzaSalto = 0;

            muestraPierdes.gameObject.SetActive(true);

            // Enviar datos
            DatosPartida.instance.RecolectaDatos();
            Redes.instance.registrarRanking();
        }
        
    }
}

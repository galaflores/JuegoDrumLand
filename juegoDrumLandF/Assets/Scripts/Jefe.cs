using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jefe : MonoBehaviour
{
    public GameObject MuestraGANAS;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            SaludJefe.instance.vidas--;
            ActualizaCorazones.instance.ActualizaVidasJefe();
            if (SaludJefe.instance.vidas == 0)
            {
                Destroy(gameObject);
                Timer.instance.timerIsRunning = false;
                MuestraGANAS.gameObject.SetActive(true);

                // Enviar datos
                DatosPartida.instance.RecolectaDatos();
                Redes.instance.registrarRanking();
            }
        }
    }
}

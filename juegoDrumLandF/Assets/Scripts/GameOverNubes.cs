using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverNubes : MonoBehaviour
{
    public GameObject muestraPierdes;

    // Update is called once per frame
    void Update()
    {
        if (SaludPersonaje.instance.vidas == 0)
        {
            GeneraBloquesNE.instance.genera = false;

            var clones = GameObject.FindGameObjectsWithTag("bloque");
            foreach (var clone in clones)
            {
                if (clone.transform.position.x > -3)
                {
                    Destroy(clone);
                }
            }

            MuevePersonajeNube.instance.animator.SetBool("muerta", true);
            MuevePersonajeNube.instance.velocidad = 0;
            MuevePersonajeNube.instance.fuerzaSalto = 0;

            muestraPierdes.gameObject.SetActive(true);

            // Enviar datos
            DatosPartida.instance.RecolectaDatos();
            Redes.instance.registrarRanking();
        }

    }
}

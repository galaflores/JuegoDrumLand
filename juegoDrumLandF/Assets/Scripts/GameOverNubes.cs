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
            MuevePersonajeNube.instance.animator.SetBool("muerta", true);
            MuevePersonajeNube.instance.velocidad = 0;
            MuevePersonajeNube.instance.fuerzaSalto = 0;

            muestraPierdes.gameObject.SetActive(true);
        }

    }
}

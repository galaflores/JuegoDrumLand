using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPartida : MonoBehaviour
{
    public static DatosPartida instance;

    public int nivel;
    private int puntos;
    private float tiempoJugado;
    public float tiempoNivel;

    private bool recolectados = false;

    private void Awake()
    {
        instance = this;
    }

    public void RecolectaDatos()
    {
        if (!recolectados)
        {
            puntos = SaludPersonaje.instance.puntos;

            if (nivel == 3)
            {
                tiempoJugado = tiempoNivel - Timer3.instance.segundos;
            }
            else
            {
                tiempoJugado = tiempoNivel - Timer.instance.segundos;
            }

            recolectados = true;

            print(puntos);
            print(nivel);
            print(tiempoJugado);
        }
    }
}

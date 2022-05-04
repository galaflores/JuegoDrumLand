using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoToca : MonoBehaviour
{
    public static NoToca instance;

    public bool toca;

    public int nivel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!toca && Input.GetKeyDown(KeyCode.L) && SaludPersonaje.instance.puntos > 0)
        {
            HUD.instance.ActualizarP(-1);
            if (nivel == 3)
            {
                PeleaJefe.instance.notasSeguidas = 0;
            }

        }
    }
}

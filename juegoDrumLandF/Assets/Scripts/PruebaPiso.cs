using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autor: Gala Flores García 
 * Comprueba si el personaje se encuentra tocando el piso
 */
public class PruebaPiso : MonoBehaviour
{
    public static bool saltando = false;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        saltando = true;
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        saltando = false;

    }
}

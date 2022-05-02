using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguila : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            SaludAguila.instance.vidas--;
            ActualizaCorazones.instance.ActualizaVidasAguila();
            if (SaludAguila.instance.vidas == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

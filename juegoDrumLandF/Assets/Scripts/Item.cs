using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private AudioSource efectoPunto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hace visible la explosi�n
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta la moneda
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(gameObject, 0.3f); // Destruye la MONEDA
            //contar la moneda recolectada
            //SaludPersonaje.instance.puntos++;
            // Actualizar el texto del contador
            HUD.instance.ActualizarPuntos();

            efectoPunto.Play();

        }
    }
    void Update()
    {
        
    }
}

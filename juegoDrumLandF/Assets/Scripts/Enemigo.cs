using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autor: Yunoe Sierra Díaz
 * Verifica la colision del Enemigo con el Personaje
 * y resta vidas
 */

public class Enemigo : MonoBehaviour
{
    [SerializeField]
    private AudioSource efectoMuerte;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Hace visible la explosi�n
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta al OJO
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(gameObject, 0.3f); // Destruye el OJO
            SaludPersonaje.instance.vidas--;
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                Destroy(other.gameObject, 2f);
                efectoMuerte.Play();
            }


        }
    }
    /*
		if (Input.GetButtonDown("Fire2"))
		{
			GameObject nuevoProyectil = Instantiate(proyectil);
			nuevoProyectil.transform.position = gameObject.transform.position;
			nuevoProyectil.SetActive(true);
		}
*/
}

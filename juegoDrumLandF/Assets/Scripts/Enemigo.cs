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

    public GameObject EliminaNota;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Hace visible la explosi�n
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta al OJO
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(gameObject); // Destruye el OJO
            Destroy(EliminaNota);

            SaludPersonaje.instance.vidas--;
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                Destroy(other.gameObject);
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

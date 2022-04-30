using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class checaPunto : MonoBehaviour
{

    [SerializeField]
    public GameObject Player;

    public static bool toca = false;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        toca = true;


    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        toca = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L) && toca)
        {
            toca = false;
            // Hace visible la explosi�n
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta la nota
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.3f);

            SaludPersonaje.instance.puntos++;
            HUD.instance.ActualizarPuntos();

        }
        else if (Input.GetKeyDown(KeyCode.L) && !toca)
        {
            //Descontar puntos
            SaludPersonaje.instance.puntos--;
            HUD.instance.ActualizarPuntos();
            if (SaludPersonaje.instance.puntos <= 0 && SaludPersonaje.instance.vidas == 0)
            {
                Destroy(Player, 0.1f);
            }
            
        }
    }

    

}

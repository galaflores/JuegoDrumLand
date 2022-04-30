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
            // Hace visible la explosi�n
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta la nota
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);

            SaludPersonaje.instance.puntos =+1;
            HUD.instance.ActualizarPuntos();
            toca = false;
        }
        else if (Input.GetKeyDown(KeyCode.L) && !toca)
        {
            //Descontar puntos
            SaludPersonaje.instance.vidas--;
            if (SaludPersonaje.instance.vidas == 0)
            {
                Destroy(Player, 0.1f);
            }
            
        }
    }

    

}

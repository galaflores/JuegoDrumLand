using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class checaPunto : MonoBehaviour
{
  
    

    public static checaPunto instance;


   // [SerializeField]
   // private AudioSource efectoPunto;

    //[SerializeField]
    public GameObject ojo;


    public static bool toca = false;

    private void Awake()
    {
        instance = this;
    }

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
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // oculta la nota
            //GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject);

            SaludPersonaje.instance.puntos ++;
            HUD.instance.ActualizarPuntos();
            
            toca = false;

            Destroy(ojo);
            //efectoPunto.Play();
        } 
        /*else if (Input.GetKeyDown(KeyCode.L) && !toca)
        {
            SaludPersonaje.instance.vidas--;
            HUD.instance.ActualizarVidas();
            //Descontar puntos
            if (SaludPersonaje.instance.vidas == 0)
            {
                Destroy(Player, 0.1f);
            }
            
        }*/
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNotasNube : MonoBehaviour
{
    private SpriteRenderer sprtRenderer;

    private bool tocar = false;



    // Start is called before the first frame update
    void Start()
    {
        sprtRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (tocar && Input.GetKeyDown(KeyCode.L))
        {
            tocar = false;
            NoToca.instance.toca = false;

            DestruirProyectil(1);
            PeleaJefe.instance.notasSeguidas++;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barra"))
        {
            tocar = true;
            NoToca.instance.toca = true;
        }

        if (collision.gameObject.CompareTag("salida"))
        {
            SaludPersonaje.instance.vidas--;
            HUD.instance.ActualizarVidas();
            PeleaJefe.instance.notasSeguidas = 0;
        }

        if (collision.gameObject.CompareTag("falla"))
        {
            PeleaJefe.instance.notasSeguidas = 0;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barra"))
        {
            tocar = false;
            NoToca.instance.toca = false;
        }

    }

    private void DestruirProyectil(int p)
    {
        // Hace visible la explosi�n
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        // oculta la nota
        GetComponent<SpriteRenderer>().enabled = false;

        Destroy(transform.parent.gameObject, 0.3f);
        HUD.instance.ActualizarP(p);
    }
}

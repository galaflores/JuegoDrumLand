using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotasMov: MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprtRenderer;
  
    public float rapidez = 0;

    private bool tocar = false;

    private float halfWidth;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprtRenderer = GetComponent<SpriteRenderer>();
    

        rb.velocity = new Vector2(-rapidez, 0);
        halfWidth = sprtRenderer.bounds.size.x / 2;
    }


    // Update is called once per frame
    void Update()
    {
        if (tocar && Input.GetKeyDown(KeyCode.L))
        {
            tocar = false;
            NoToca.instance.toca = false;
            DestruirProyectil(1);
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
        // oculta la moneda
        sprtRenderer.enabled = false;
   
        Destroy(transform.parent.gameObject, 0.3f);
        HUD.instance.ActualizarP(p);
    }
}

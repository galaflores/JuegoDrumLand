using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNotasNube : MonoBehaviour
{
    private SpriteRenderer sprtRenderer;

    private bool tocar = false;

    private float halfWidth;


    // Start is called before the first frame update
    void Start()
    {
        sprtRenderer = GetComponent<SpriteRenderer>();
        halfWidth = sprtRenderer.bounds.size.x / 2;
    }


    // Update is called once per frame
    void Update()
    {
        if (tocar && Input.GetKeyDown(KeyCode.L))
        {
            tocar = false;
            //NoToca.instance.toca = false;
            DestruirProyectil(1);
        }
        else
        {
            if (gameObject.transform.position.x + halfWidth < -Screen.width / 200)
            {
                DestruirProyectil(-1);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barra"))
        {
            tocar = true;
            //NoToca.instance.toca = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barra"))
        {
            tocar = false;
            //NoToca.instance.toca = false;
        }

    }

    private void DestruirProyectil(int p)
    {
        Destroy(transform.parent.gameObject);
        HUD.instance.ActualizarP(p);
    }
}

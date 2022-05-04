using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil3: MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadX = 10;
    private SpriteRenderer rendererProyectil;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocidadX, 0);
        rendererProyectil = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, 5);
        if (gameObject.transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mago") && PeleaJefe.instance.magoTirado)
        {
            PeleaJefe.instance.disparos--;
            Destroy(gameObject);
        }
    }
}
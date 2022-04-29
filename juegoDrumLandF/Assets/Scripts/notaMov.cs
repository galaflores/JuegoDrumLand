using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaMov : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;


    private SpriteRenderer sprRenderer;
    //velocidad
    public float velocidadX = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(-movHorizontal * velocidadX, rb.velocity.y);

        //Animaci?n
        float velocidad = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("velocidad", velocidad);
        //Direcci?n
        sprRenderer.flipX = rb.velocity.x < 0;

        animator.SetBool("saltando", !PruebaPiso.saltando);

    }
}

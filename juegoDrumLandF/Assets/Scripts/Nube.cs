using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private float width;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = boxCollider.size.x;
        speed = -Random.Range(1.5f, 3);
        rb.velocity = new Vector2(speed, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (-Screen.width / 100 / 2) - width / 2)
        {
            Vector2 vec = new Vector2(Screen.width / 100 / 2 + width / 2, transform.position.y);
            transform.position = vec;
        }
        
    }
}

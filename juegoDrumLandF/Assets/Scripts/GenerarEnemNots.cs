using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemNots: MonoBehaviour
{
    private GameObject bloque;

    public GameObject nota;

    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject enemigo4;

    public float velocidad;
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarBloque());
        bloque = new GameObject();
        
    }

    private IEnumerator GenerarBloque()
    {
        while (true)
        {
            yield return new WaitForSeconds(tempo);

            if (Random.value < 0.5f && MuevePersonaje.instance.velX > 0.1)
            {
                // Generar bloque
                GameObject nuevoBloque = Instantiate(bloque);
                nuevoBloque.transform.position = gameObject.transform.position;
                nuevoBloque.tag = "bloque";
                Rigidbody2D bloqueRB = nuevoBloque.AddComponent<Rigidbody2D>();
                bloqueRB.gravityScale = 0;
                bloqueRB.velocity = new Vector2(-velocidad, 0);

                // Generar nota
                GameObject nuevaNota = Instantiate(nota);
                nuevaNota.transform.parent = nuevoBloque.transform;
                nuevaNota.transform.position = new Vector3(nuevoBloque.transform.position.x, nuevoBloque.transform.position.y, -1);
                nuevaNota.transform.position +=  new Vector3(0, Random.Range(-0.2f, 0.2f), 0);
                nuevaNota.SetActive(true);

                // Generar enemigo
                GameObject nuevoEnemigo;
                int numEnemigo = Random.Range(1, 5);

                switch (numEnemigo)
                {
                    case 1:
                        nuevoEnemigo = Instantiate(enemigo1);
                        break;
                    case 2:
                        nuevoEnemigo = Instantiate(enemigo2);
                        break;
                    case 3:
                        nuevoEnemigo = Instantiate(enemigo3);
                        break;
                    default:
                        nuevoEnemigo = Instantiate(enemigo4);
                        break;
                }

                nuevoEnemigo.transform.parent = nuevoBloque.transform;
                nuevoEnemigo.transform.position = new Vector3(nuevoBloque.transform.position.x, nuevoBloque.transform.position.y, -1);
                nuevoEnemigo.transform.position += new Vector3(0, -Random.Range(2f, 6f), 0);
                nuevoEnemigo.SetActive(true);
            }
        }

    }
}

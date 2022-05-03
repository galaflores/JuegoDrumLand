using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarEnemigo : MonoBehaviour
{
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject enemigo4;

    public static GenerarEnemigo instance;

    private void Awake()
    {
        instance = this;
    }

    public void Generar(GameObject nota)
    {
        int numEnemigo = Random.Range(1, 5);
        GameObject nuevoEnemigo;

        if (numEnemigo == 1)
        {
            nuevoEnemigo = Instantiate(enemigo1);
        }
        else if (numEnemigo == 2)
        {
            nuevoEnemigo = Instantiate(enemigo2);
        } 
        else if (numEnemigo == 3)
        {
            nuevoEnemigo = Instantiate(enemigo3);
        } 
        else
        {
            nuevoEnemigo = Instantiate(enemigo4);
        }

        nuevoEnemigo.transform.position = gameObject.transform.position + new Vector3(0, 0, 0);
        nuevoEnemigo.SetActive(true);
    }
}

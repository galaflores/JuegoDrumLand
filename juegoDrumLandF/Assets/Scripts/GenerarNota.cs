using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarNota : MonoBehaviour
{

    public GameObject nota;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarP());
    }

    private IEnumerator GenerarP()
    {
        //while (MuevePersonaje.instance.velX > 0.1)
        while(true)
        {
            //if (MuevePersonaje.instance.velX > 0.1)
            //{
                yield return new WaitForSeconds(0.3f);

                if (Random.value < 0.5f)
                {
                    GameObject nuevoProyectil = Instantiate(nota);
                    nuevoProyectil.transform.position = gameObject.transform.position;
                    nuevoProyectil.SetActive(true);
                }
            //}
           
          
        }

    }
}
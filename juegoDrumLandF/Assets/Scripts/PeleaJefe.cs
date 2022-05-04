using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeleaJefe : MonoBehaviour
{
    public static PeleaJefe instance;

    public int notasSeguidas = 0;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notasSeguidas == 10)
        {
            notasSeguidas = 0;
            GeneraBloquesNE.instance.genera = false;
            var clones = GameObject.FindGameObjectsWithTag("bloque");
            foreach (var clone in clones)
            {
                if (clone.transform.position.x > -3)
                {
                    Destroy(clone);
                }
            }

        }
        
    }
}

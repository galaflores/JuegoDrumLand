using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PeleaJefe : MonoBehaviour
{
    public static PeleaJefe instance;

    public int notasSeguidas = 0;

    private int vidasJefe = 3;
    private int disparos = 5;

    [SerializeField]
    private Image CorazonJ1;
    [SerializeField]
    private Image CorazonJ2;
    [SerializeField]
    private Image CorazonJ3;


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

    private void ActualizarVidasJefe()
    {
        switch (vidasJefe)
        {
            case 2:
                CorazonJ3.enabled = false;
                break;
            case 1:
                CorazonJ2.enabled = false;
                break;
            case 0:
                CorazonJ1.enabled = false;
                break;
        }
    }
}

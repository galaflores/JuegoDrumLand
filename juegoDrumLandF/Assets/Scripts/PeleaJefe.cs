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
    public int disparos = 5;
    public bool magoTirado = false;

    public GameObject muestraGanas;

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

    // Update is called once per frame
    void Update()
    {
        if (vidasJefe > 0)
        {
            if (notasSeguidas == 20)
            {
                magoTirado = true;
                GeneraBloquesNE.instance.genera = false;
                var clones = GameObject.FindGameObjectsWithTag("bloque");
                foreach (var clone in clones)
                {
                    if (clone.transform.position.x > -3)
                    {
                        Destroy(clone);
                    }
                }

                if (disparos == 0)
                {
                    magoTirado = false;
                    disparos = 5;
                    vidasJefe--;
                    ActualizarVidasJefe();
                    notasSeguidas = 0;
                    GeneraBloquesNE.instance.genera = true;

                }
            }
        }
        else
        {
            GeneraBloquesNE.instance.genera = false;
            magoTirado = true;
            muestraGanas.gameObject.SetActive(true);
            PlayMusica3.instance.audioNivel.Stop();

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

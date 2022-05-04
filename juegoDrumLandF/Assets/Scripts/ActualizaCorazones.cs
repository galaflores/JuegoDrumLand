using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActualizaCorazones : MonoBehaviour
{
    //3 im?genes (corazones)
    [SerializeField] //para accederlo desde unity
    private Image Corazon1;
    [SerializeField]
    private Image Corazon2;
    [SerializeField]
    private Image Corazon3;

    public static ActualizaCorazones instance;

    private void Awake()
    {
        instance = this;
    }

    public void ActualizaVidasJefe()
    {
        int vidas = SaludJefe.instance.vidas;

        if (vidas == 10)
        {
            Corazon3.enabled = false;
        } 
        else if (vidas == 5)
        {
            Corazon2.enabled = false;
        }
        else if (vidas == 0)
        {
            Corazon3.enabled = false;
        }
    }
}


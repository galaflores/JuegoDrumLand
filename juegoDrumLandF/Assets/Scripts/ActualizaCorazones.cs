using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActualizaCorazones : MonoBehaviour
{
    //3 imágenes (corazones)
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

    public void ActualizaVidasAguila()
    {
        int vidas = SaludAguila.instance.vidas;
        //switch (vidas)
        //{
        //    case 2:
        //        Corazon3.enabled = false;
        //        break;
        //    case 1:
        //        Corazon2.enabled = false;
        //        break;
        //    case 0:
        //        Corazon1.enabled = false;
        //        break;
        //}
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


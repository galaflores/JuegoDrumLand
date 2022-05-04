using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    //3 imágenes (corazones)
    [SerializeField] //para accederlo desde unity
    private Image Corazon1;
    [SerializeField]
    private Image Corazon2;
    [SerializeField]
    private Image Corazon3;

    //contador de monedas
    [SerializeField]
    private TextMeshProUGUI txtMonedas;


    public static HUD instance;

    private void Awake()
    {
        instance = this;
    }

    public void ActualizarVidas()
    {
        int vidas = SaludPersonaje.instance.vidas;
        switch (vidas)
        {
            case 2:
                Corazon3.enabled = false;
                break;
            case 1:
                Corazon2.enabled = false;
                break;
            case 0:
                Corazon1.enabled = false;
                break;
        }
    }

    public void ActualizarP(int p)
    {
        SaludPersonaje.instance.puntos += p;
        txtMonedas.text = SaludPersonaje.instance.puntos.ToString();
    }
}

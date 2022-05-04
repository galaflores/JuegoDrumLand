using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusica3 : MonoBehaviour
{

    public static PlayMusica3 instance;

    public AudioSource audioNivel;

    public bool estado = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioNivel = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (estado && MuevePersonajeNube.instance.velX > 0)
        {
            PlayM();
            estado = !estado;
        }
        else if (!estado && MuevePersonajeNube.instance.velX == 0)
        {
            PausaM();
            estado = !estado;
        }
    }


    private void PausaM()
    {
        audioNivel.Stop();
    }

    private void PlayM()
    {
        audioNivel.Play();
    }

}

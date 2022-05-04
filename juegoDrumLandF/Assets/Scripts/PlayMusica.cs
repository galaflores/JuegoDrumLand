using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusica : MonoBehaviour
{

    public static PlayMusica instance;

    public AudioSource audioNivel;

    public bool estado = true;


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
        if (estado && MuevePersonaje.instance.velX > 0)
        {
            PlayM();
            estado = !estado;
        }
        else if (!estado && MuevePersonaje.instance.velX == 0)
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

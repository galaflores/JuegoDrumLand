using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusica : MonoBehaviour
{

    public static PlayMusica instance;

    public AudioSource audioNivel;

    private bool inicio = true;


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
        if(inicio && Input.GetKeyDown(KeyCode.Space))
        {
            audioNivel.Play();
            inicio = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer3 : MonoBehaviour
{
    public static Timer3 instance;

    public float segundos = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI tiempo;
    public GameObject muestraPierdes;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        tiempo.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (segundos > 0)
            {
                segundos -= Time.deltaTime;
                DisplayTime(segundos);
            }
            else
            {

                segundos = 0;
                timerIsRunning = false;
                MuevePersonajeNube.instance.animator.SetBool("muerta", true);
                MuevePersonajeNube.instance.velocidad = 0;
                MuevePersonajeNube.instance.fuerzaSalto = 0;

                GeneraBloquesNE.instance.genera = false;

                muestraPierdes.gameObject.SetActive(true);
            }
        }
    }

}
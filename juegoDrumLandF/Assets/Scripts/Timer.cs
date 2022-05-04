using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    public float segundos = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI tiempo;
    public GameObject muestraPierdes;
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
                MuevePersonaje.instance.animator.SetBool("muerta", true);
                MuevePersonaje.instance.velocidad = 0;
                MuevePersonaje.instance.fuerzaSalto = 0;

                muestraPierdes.gameObject.SetActive(true);
            }
        }
    }
    
}
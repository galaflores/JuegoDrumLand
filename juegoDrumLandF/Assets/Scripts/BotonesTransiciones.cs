using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Rodrigo Alfredo Mendoza España
// scripts para cambiar de escenas
public class BotonesTransiciones : MonoBehaviour
{
    //Para aplicarse a un botón que cierra la aplicación
    public void SalirAplicacion()
    {
        Application.Quit();
    }

    public void LogOff()
    {
        SceneManager.LoadScene("Login");
    }

    public void Loading()
    {
        SceneManager.LoadScene("Loading");
    }
}

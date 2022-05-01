using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Rodrigo Alfredo Mendoza Espa�a
// scripts para cambiar de escenas
public class BotonesTransiciones : MonoBehaviour
{
    //Para aplicarse a un bot�n que cierra la aplicaci�n
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

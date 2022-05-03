using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambio : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;

    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CambiarNivel(indiceNivel);
        }

        if(pasarNivel)
        {
            CambiarNivel(indiceNivel);
        }

    }
}

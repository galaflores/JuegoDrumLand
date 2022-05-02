using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject control;

    public bool estaPausado = false;

    public void Pausar()
    {
        estaPausado = !estaPausado;
        control.SetActive(estaPausado);
        Time.timeScale = estaPausado ? 0 : 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }

    }

}

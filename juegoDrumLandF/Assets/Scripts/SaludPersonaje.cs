using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludPersonaje : MonoBehaviour
{
    public int vidas = 3;
    public int puntos = 0;

    public static SaludPersonaje instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}

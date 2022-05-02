using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludAguila : MonoBehaviour
{
    public int vidas = 3;

    public static SaludAguila instance;
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

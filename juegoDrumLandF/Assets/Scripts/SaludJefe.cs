using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludJefe : MonoBehaviour
{
    public int vidas = 3;

    public static SaludJefe instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

}

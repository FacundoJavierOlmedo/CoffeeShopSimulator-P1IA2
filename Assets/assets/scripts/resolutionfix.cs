using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolutionfix : MonoBehaviour
{

    void Start()
    {
        // Forzar resolución 288x600 en modo ventana
        Screen.SetResolution(432, 900, false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resolutionfix : MonoBehaviour
{

    void Start()
    {
        // Forzar resoluci�n 288x600 en modo ventana
        Screen.SetResolution(432, 900, false);
    }

}

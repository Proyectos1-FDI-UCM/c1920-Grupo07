using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{   
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
            GameManager.instance.CambioTiempo();        
    }
}

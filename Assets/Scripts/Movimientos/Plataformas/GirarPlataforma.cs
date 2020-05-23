﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarPlataforma : MonoBehaviour
{
    [SerializeField] public float rotacion;
    void Update()
    {
        if (GameManager.instance.Tiempo())          //  Se encarga de detener la rotación
            this.transform.Rotate(0, 0, 0);         //  en caso de que se pare el tiempo.

        else this.transform.Rotate(0, 0, rotacion); //  Realiza la rotación mientras no
    }                                               //  se pare el tiempo.
}

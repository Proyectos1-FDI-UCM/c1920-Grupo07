using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarPlataforma : MonoBehaviour
{
    [SerializeField] public float rotacion;
    void Update()
    {
        if (GameManager.instance.Tiempo())
            this.transform.Rotate(0, 0, 0);
        else this.transform.Rotate(0, 0, rotacion);
    }
}

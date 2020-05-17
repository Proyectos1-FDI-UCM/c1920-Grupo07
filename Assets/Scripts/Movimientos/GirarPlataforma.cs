using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarPlataforma : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance.Tiempo())
            this.transform.Rotate(0, 0, 0);
        else this.transform.Rotate(0, 0, 5);
    }
}

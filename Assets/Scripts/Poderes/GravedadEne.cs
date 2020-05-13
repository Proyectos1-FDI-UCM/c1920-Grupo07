using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadEne : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool miGravedad = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(GameManager.instance.GetGravedad() == false && miGravedad != GameManager.instance.GetGravedad())
        {
            rb.gravityScale *= -1;
            transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            miGravedad = !miGravedad;
        }
    }

    public void CambiarGravedad()
    {
        if(GameManager.instance.GetGravedad() != miGravedad && GameManager.instance.GetGravedad() == true)
        {
            rb.gravityScale *= -1;
            transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            miGravedad = !miGravedad;
        }
    }
}

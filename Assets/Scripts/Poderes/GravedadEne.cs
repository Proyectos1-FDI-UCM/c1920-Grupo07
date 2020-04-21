using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadEne : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer ene;
    private bool miGravedad = false;
    void Start()
    {
        ene = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(GameManager.instance.GetGravedad() == false && miGravedad != GameManager.instance.GetGravedad())
        {
            rb.gravityScale *= -1;
            ene.flipY = false;
            miGravedad = !miGravedad;
        }
    }
    public void CambiarGravedad(bool gravedad)
    {
        if(gravedad != miGravedad && GameManager.instance.GetGravedad() == true)
        {
            rb.gravityScale *= -1;
            ene.flipY = true;
            miGravedad = !miGravedad;
        }
    }
}

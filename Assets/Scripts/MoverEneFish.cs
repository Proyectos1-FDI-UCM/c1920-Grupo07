using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoverEneFish : MonoBehaviour
{
    public float dist, velocidad;

    private SpriteRenderer ene;
    private Rigidbody2D rb;
    private Vector2 velActual;

    private float pos;
    private float gravedad;

    private bool cambio;
    private bool recuperaVel = false;
    private bool velAct = false;

    void Start()
    {
        ene = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos = transform.position.y;
        rb.velocity = new Vector2(velocidad, 0);
        gravedad = rb.gravityScale;
    }

    void Update()
    {
        if (GameManager.instance.Tiempo())
        {
            if (!velAct)
            {
                velActual = rb.velocity;
                velAct = true;
            }
            rb.gravityScale = 0;    //Para que se quede parado en el aire
            rb.velocity = new Vector2(0, 0);
            recuperaVel = true;
        }
        else if (!GameManager.instance.Tiempo())
        {
            velAct = false;
            if (recuperaVel)
            {
                rb.velocity = velActual;
                recuperaVel = false;
                if (GameManager.instance.GetGravedad()) //Devolverle la gravedad en función de si esta invertida o no
                    rb.gravityScale = -gravedad;
                else
                    rb.gravityScale = gravedad;
            }
        }

        if (GameManager.instance.GetGravedad())
        {
            ene.flipX = true;
        }
        else
        {
            ene.flipX = false;
        }
        if (transform.position.y > pos + dist)  //Controlar que no se pase de la distancia
        {
            cambio = true;
            ene.flipY = true;
        }

        else if (transform.position.y < pos)
        {
            cambio = false;
            ene.flipY = false;
        }
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (cambio)
                rb.velocity = new Vector2(0, -velocidad);
            else
                rb.velocity = new Vector2(0, +velocidad);
        }
    }
}

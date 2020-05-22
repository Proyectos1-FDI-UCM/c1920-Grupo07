using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilY : MonoBehaviour
{
    [SerializeField] private float dist, velocidad;

    private Rigidbody2D rb;
    private Vector2 velActual;

    private float pos;

    private bool cambio;
    private bool recuperaVel = false;
    private bool velAct = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos = transform.position.y;
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
            }
        }

        if (transform.position.y > pos + dist)  // Controlar que no se pase de la distancia
        {
            cambio = true;
        }

        else if (transform.position.y < pos - dist)
        {
            cambio = false;
        }
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (cambio)
                rb.velocity = new Vector2(0, -velocidad);
            else
                rb.velocity = new Vector2(0, velocidad);
        }
    }
}
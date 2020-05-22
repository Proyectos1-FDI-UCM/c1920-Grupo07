using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilX : MonoBehaviour
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
        pos = transform.position.x;
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

        if (transform.position.x > pos + dist)  // Controlar que no se pase de la distancia
        {
            cambio = true;
        }

        else if (transform.position.x < pos - dist)
        {
            cambio = false;
        }
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (cambio)
                rb.velocity = new Vector2(-velocidad,0);
            else
                rb.velocity = new Vector2(velocidad,0);
        }
    }
}
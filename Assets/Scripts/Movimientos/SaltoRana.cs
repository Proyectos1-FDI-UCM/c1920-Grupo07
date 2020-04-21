using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoRana : MonoBehaviour
{
    public float distRight, distLeft, velocidad, salto, tiempoEntreSalto;

    private SpriteRenderer ene;
    private Rigidbody2D rb;
    private Vector2 velActual;
    private Animator anim;

    private float pos, gravedad, temp;

    private bool cambio, suelo;
    private bool recuperaVel = false;
    private bool velAct = false;
    private bool cambioSalto = false;

    void Start()
    {
        ene = GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = transform.position.x;
        rb.velocity = new Vector2(velocidad, 0);
        gravedad = rb.gravityScale;
        temp = tiempoEntreSalto;
    }

    void Update()
    {
        temp = temp - Time.deltaTime;
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
            if (!cambioSalto)
            {
                salto = -salto;
                cambioSalto = true;
            }
        }
        else
        {
            if (cambioSalto)
            {
                salto = -salto;
                cambioSalto = false;
            }
        }
        if (rb.velocity.y >= -0.01 && rb.velocity.y <= 0.01) suelo = true;
        else suelo = false;
        if (transform.position.x > pos + distRight && suelo)  //Controlar que no se pase de la distancia
        {
            cambio = true;
            ene.flipX = true;
        }

        else if (transform.position.x < pos - distLeft && suelo)
        {
            cambio = false;
            ene.flipX = false;
        }
        if (suelo) anim.SetBool("Volar", false);
        else anim.SetBool("Volar", true);
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (cambio && suelo)
            {
                if (temp <= 0)
                {
                    rb.AddForce(new Vector2(-velocidad, salto), ForceMode2D.Impulse);
                    temp = tiempoEntreSalto;
                }
            }
            else if (suelo)
                if (temp <= 0)
                {
                    rb.AddForce(new Vector2(velocidad, salto), ForceMode2D.Impulse);
                    temp = tiempoEntreSalto;
                }
        }
    }
}

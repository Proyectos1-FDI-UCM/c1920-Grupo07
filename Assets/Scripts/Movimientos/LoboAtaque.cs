using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboAtaque : MonoBehaviour
{
    
    private float direccion = 0.1f;
    public float ataque, atacar, salto;
    private float gravedad;
    private Vector2 velActual;

    public DetectorLobo scriptDet;              // Necesario para el booleano que se activa al pasar sobre el detector.
    public PlayerController scriptJug;          // Necesario para el valor del input de movimiento, que indica si el jugador va a la izquierda o a la derecha.

    private SpriteRenderer lobo;

    public GameObject Player;
    public GameObject Lobo;
    private Rigidbody2D rb;
    public Animator anim;

    private bool recuperaVel = false;
    private bool cambioSalto = false;
    private bool velAct = false;
    public bool inicio = true;

   

    void Start()
    {
       
        rb = this.GetComponent<Rigidbody2D>();
        lobo = this.GetComponent<SpriteRenderer>();
        gravedad = rb.gravityScale;
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    { 
        if (scriptDet.iniciar)
        {
            if (!GameManager.instance.Tiempo())
            {
                if (inicio && scriptJug.movimientoInput < direccion)                // Si el jugador se acerca al lobo, éste salta hacia él.
                {
                    rb.AddForce(new Vector2(ataque, salto), ForceMode2D.Impulse);
                    inicio = false;
                    
                }   
                if (inicio == false && scriptJug.movimientoInput > direccion)       // Si el jugador se aleja del lobo, éste se aparta él.
                {
                    rb.AddForce(new Vector2(atacar, salto), ForceMode2D.Impulse);
                    inicio = !inicio;
                }
            }
        }
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
            rb.gravityScale = 0;
            rb.velocity = new Vector2 (0,0);
            recuperaVel = true;
            
        }
        else if (!GameManager.instance.Tiempo())
        {
            velAct = false; 
            if (recuperaVel)
            {
                rb.velocity = velActual;
                recuperaVel = false;
                if (GameManager.instance.GetGravedad()) // Devolverle la gravedad en función de si está invertida o no
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


        //  if (scriptDet.iniciar == true) Debug.Log("Iniciado");             // (No necesario) Ayuda a determinar al desarrollador la posición del detector estando dentro del juego.

       
    }

}
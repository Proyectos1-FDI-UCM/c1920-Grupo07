using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboAtaque : MonoBehaviour
{
    
    public float ataque, atacar, salto, temp, tiempoE;
    private float gravedad;
    private Vector2 velActual;

    public DetectorLobo scriptDet;
    public PlayerController scriptJug;      

    private SpriteRenderer lobo;

    private Rigidbody2D rb;
    public Animator anim;

    private bool recuperaVel = false;
    private bool cambioSalto = false;
    private bool velAct = false;
    public bool inicio = true;
    public bool iniciado = false;


    public void Ataque()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (inicio && temp <=0)              
            {
                anim.Play("LoboAtaque");
                rb.AddForce(new Vector2(ataque, salto), ForceMode2D.Impulse);
                temp = tiempoE;
                Invoke("RestartAnim", 1.0f);
                inicio = false;
            }
            
        }
        
    }

    public void Vuelta ()
    {
        if (!GameManager.instance.Tiempo())
        {
            if (inicio == false && temp <= 0)
            {
                anim.Play("LoboVuelta");
                rb.AddForce(new Vector2(atacar, salto), ForceMode2D.Impulse);
                Debug.Log("Volviendo");
                temp = tiempoE;
                Invoke("RestartAnim", 1.0f);
                inicio = true;
            }

            
        }

        Invoke("RestartBool", 2f);
    }
    public void RestartBool()
    {
        scriptDet.iniciar = false;
    }
    public void RestartAnim()
    {
        anim.Play("Parado");
    }

    public void Repeticion()
    {
        Ataque();
        Vuelta();
    }

    public void Espera()
    {
        inicio = true;
    }

    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        lobo = this.GetComponent<SpriteRenderer>();
        gravedad = rb.gravityScale;
        anim = GetComponent<Animator>();
        temp = tiempoE;
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
      
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboAtaque : MonoBehaviour
{
    public float ataque,atacar, salto, distancia,distance, tiempoEntreSalto;
    private float gravedad, temp;
    private Vector2 velActual;

    private SpriteRenderer lobo;
    public Sprite saltar, bajar, normal;

    public GameObject Player;
    public GameObject Detector;
    private Vector2 posiIni, posAct;
    private Rigidbody2D rb;
    private Animator anim;

    private bool recuperaVel = false;
    private bool cambioSalto = false;
    private bool velAct = false;
    public bool inicio = true;
    public bool iniciar = false;

   
    private void OnTriggerEnter2D(Collider2D Player)
    {

        Debug.Log("Está en el trigger");
        lobo.sprite = saltar;
        iniciar = true;
        rb.AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
        anim.SetBool("Ataque", true);


    }
    private void OnTriggerStay2D(Collider2D Player)
    {
        iniciar = false;
    }
    void Start()
    {
        
        Detector = this.transform.GetChild(0).gameObject;
        rb = this.GetComponent<Rigidbody2D>();
        lobo = this.GetComponent<SpriteRenderer>();
        gravedad = rb.gravityScale;
        anim = GetComponent<Animator>();
        
    }
    private void FixedUpdate()
    {
        if (iniciar)
        {
            if (!GameManager.instance.Tiempo())
            {
                if (inicio)
                {
                    rb.AddForce(new Vector2(ataque, 20 / 400), ForceMode2D.Impulse);
                    inicio = false;

                   
                    
                }
                if (inicio == false && Detector.transform.position.x >= Player.transform.position.x - 5)
                {
                    rb.AddForce(new Vector2(-5, 20 / 400), ForceMode2D.Impulse);
                    inicio = !inicio;
                }
            }
        }
    }
    void Update()
    {
        temp = temp - Time.time;
        temp = tiempoEntreSalto;

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
                if (GameManager.instance.GetGravedad()) //Devolverle la gravedad en función de si esta invertida o no
                    rb.gravityScale = -gravedad;
                else
                    rb.gravityScale = gravedad;
            }
        }
        if (GameManager.instance.GetGravedad())
        {
            lobo.flipY = true;
            if (!cambioSalto)
            {
                salto = -salto;
                cambioSalto = true;
            }
        }

        else
        {
            lobo.flipY = false;
            if (cambioSalto)
            {
                salto = -salto;
                cambioSalto = false;
            }

        }

          

       
    }

}
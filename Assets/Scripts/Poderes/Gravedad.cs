using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    private Rigidbody2D rb;    
    private bool active = false;
    private float gravedad;
    private SpriteRenderer jug;
    public SoundManager sonido;
    public Animator anim;

    void Start()
    {
        jug = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gravedad = rb.gravityScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.GetCapsulasRest() > 0 && !GameManager.instance.GetEscalera())
        {
            rb.gravityScale *= -1;

            if (!active)
            {
                active = true;
                GameManager.instance.SetGravedad(active); 
            }
            else
            {
                active = false;
                GameManager.instance.SetGravedad(active);
            }            
        }

        if (!GameManager.instance.GetGravedad() && !GameManager.instance.GetEscalera())
            rb.gravityScale = gravedad;

        if (GameManager.instance.GetGravedad()) //Rotar el sprite según la gravedad
            jug.flipY = true;

        else
            jug.flipY = false;

        if (GameManager.instance.GetGravedad())
        {

            anim.SetBool("Gravedad", true);
            anim.SetBool("Gravedad2", false);

        }
        else
        {

            anim.SetBool("Gravedad", false);
            anim.SetBool("Gravedad2", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.GetCapsulasRest() > 0 && !GameManager.instance.GetEscalera())
        {
            sonido.audioGravedad();
        }
    }

      
}

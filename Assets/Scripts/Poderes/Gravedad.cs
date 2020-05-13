using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    private Rigidbody2D rb; 
    private float gravedad;
    private SpriteRenderer jug;
    [SerializeField] private SoundManager sonido;
    [SerializeField] private Animator anim;

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

            if (!GameManager.instance.GetGravedad())                          
                GameManager.instance.SetGravedad(true);             
            else                            
                GameManager.instance.SetGravedad(false);                     
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
            sonido.audioGravedad();        
    }      
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer jug;

    public float speed = 8.0f;
    public float jumpForce = 12.0f;    
    public float distance;
    public float movimientoInput;
    private float gravedad;

    private bool isGrounded;
    private bool isWalking; 

    void Start()
    {
        jug = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gravedad = rb.gravityScale;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Escalar>() != null)  //Al estar en la escalera tener g = 0 y tener input vertical
        {
            GameManager.instance.SetEscalera(true);
            rb.gravityScale = 0;
            if (Input.GetKeyDown(KeyCode.W))
            {
                movimientoInput = Input.GetAxisRaw("Vertical");

                rb.velocity = new Vector2(rb.velocity.x, movimientoInput * speed);
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D other)  //Al salir de la escalera volver a tener la g anterior
    {
        if (other.GetComponent<Escalar>() != null)
        {
            GameManager.instance.SetEscalera(false);
            if(GameManager.instance.GetGravedad())
                rb.gravityScale = -gravedad;
            else
                rb.gravityScale = gravedad;
        }
    }    
    
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        isGrounded = GameManager.instance.GetSuelo();
    }

    void FixedUpdate()
    {
        ApplyMovement();        
    }

    private void CheckMovementDirection()
    {
        if (movimientoInput < 0)        //Rotar el sprite según la dir  
            jug.flipX = true;
               

        else if (movimientoInput > 0)             
            jug.flipX = false;
                

        if (rb.velocity.x != 0)         //Si esta moviendose o no poner anim idle
            isWalking = true;

        else
            isWalking = false;
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }    

    private void CheckInput()
    {
        movimientoInput = Input.GetAxisRaw("Horizontal");

        if (GameManager.instance.GetParedL() && movimientoInput < 0 )  //Si está chocando con la paredL no funcione el input L
            movimientoInput = 0;

        else if (GameManager.instance.GetParedR() && movimientoInput > 0 )
            movimientoInput = 0;
      
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Jump()
    {
        if (isGrounded && !GameManager.instance.GetGravedad() && !GameManager.instance.GetEscalera())      //Salto con gravedad desactivada
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        else if (isGrounded && GameManager.instance.GetGravedad() && !GameManager.instance.GetEscalera())  //Salto con gravedad activada
            rb.velocity = new Vector2(rb.velocity.x, -jumpForce);
    }    

    private void ApplyMovement()
    {
        rb.velocity = new Vector2 (speed * movimientoInput, rb.velocity.y);
    }
    
}

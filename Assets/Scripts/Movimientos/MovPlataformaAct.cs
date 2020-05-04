using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataformaAct : MonoBehaviour
{

    private Rigidbody2D rb;

    public float deltaX;

    public bool inicio = true;

    public Sprite florRoja, florAzul;

    GameObject child;

    public void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player" && inicio) Mov1();
        else if (Player.tag == "Player" && inicio == false) Mov2();
    }

    public void Mov1()
    {
        child.GetComponent<SpriteRenderer>().sprite = florRoja;
        Movimiento();
        Invoke("Res2", 3.0f);
        inicio = false;
    }

    public void Movimiento()
    {
        deltaX = 3;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(deltaX, 0);
        
    }

    public void Mov2()
    {
        if (inicio == false)
        {
            child.GetComponent<SpriteRenderer>().sprite = florRoja;
            deltaX = -3;
            rb.velocity = new Vector2(deltaX, 0);
            Invoke("Res1", 3.0f);
        }
    }

    public void Res1()
    {
        rb.velocity = new Vector2(0, 0);
        inicio = true;
        child.GetComponent<SpriteRenderer>().sprite = florAzul;
    }
    public void Res2()
    {
        rb.velocity = new Vector2(0, 0);
        inicio = false;
        child.GetComponent<SpriteRenderer>().sprite = florAzul;
    }
    void Start()
    {
        child = this.transform.GetChild(0).gameObject;
    }


    void Update()
    {
        
    }
}

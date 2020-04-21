using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuerta : MonoBehaviour
{

    public Sprite florRoja1;
    public float distancia, velocidad;

    private bool inicio = false;
    private Vector2 posIni;
    private Rigidbody2D rb;
    private GameObject child;



    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.GetComponent<PlayerController>() != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = florRoja1;
            inicio = true;            
        }
    }

    void Start()
    {
        child = this.transform.GetChild(0).gameObject;
        rb = child.GetComponent<Rigidbody2D>();
        posIni = new Vector2(child.transform.position.x, child.transform.position.y);
    }

    void Update()
    {
        if (inicio)
        {
            if (child.transform.position.y < posIni.y + distancia)            
                rb.velocity = new Vector2(0, velocidad);
            
            if (child.transform.position.y > posIni.y + distancia)            
                inicio = false;
                        
            if (inicio == false)            
                rb.velocity = new Vector2(0, 0);            
        }
    }
}

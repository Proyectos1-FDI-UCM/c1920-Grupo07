using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlat : MonoBehaviour
{
    public Sprite florRoja;
    public float velocidad, distancia;

    private Sprite normal;
    private Rigidbody2D rb;
    private Vector2 posIni, velAct, velTiempo;

    private bool inicio = true;
    private bool cambio = false;

    GameObject child;


    private void OnTriggerEnter2D(Collider2D Player)
    {

        if (Player.GetComponent<PlayerController>() != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = florRoja;
            if (inicio)
            {
                rb.velocity = new Vector2(0, velocidad);
                inicio = false;
            }
            else
                rb.velocity = velAct;
        }
    }

    private void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.GetComponent<PlayerController>() != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = normal;
            velAct = rb.velocity;
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Start()
    {
        child = this.transform.GetChild(0).gameObject;
        rb = child.GetComponent<Rigidbody2D>();
        posIni = new Vector2(child.transform.position.x, child.transform.position.y);
        normal = this.GetComponent<SpriteRenderer>().sprite;
        
    }
    void Update()
    {
        if (GameManager.instance.Tiempo())
        {
            if (!cambio)
            {
                velTiempo = rb.velocity;
                cambio = true;
            }

            rb.velocity = Vector2.zero;
        }

        else if (!GameManager.instance.Tiempo())
        {

            if (cambio)
            {
                rb.velocity = velTiempo;
                cambio = false;
            }

            if (child.transform.position.y > posIni.y + distancia)
                rb.velocity = new Vector2(0, -velocidad);

            else if (child.transform.position.y < posIni.y - distancia)
                rb.velocity = new Vector2(0, velocidad);
        }
    }
}

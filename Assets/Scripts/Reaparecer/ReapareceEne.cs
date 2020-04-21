using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapareceEne : MonoBehaviour
{
    Vector2 posIni;
    private Rigidbody2D rb;
    private float gravedadIni;
    void Start()
    {
        posIni = new Vector2(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        gravedadIni = rb.gravityScale;
    }

    public void Reaparece()
    {
        transform.position = posIni;
        if(rb.isKinematic!=true)//Si no es plataformas
        rb.gravityScale = gravedadIni;
    }

}

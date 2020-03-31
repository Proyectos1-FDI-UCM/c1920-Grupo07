using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadEne : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.GetCapsulasRest() > 0 && !GameManager.instance.GetEscalera())
            rb.gravityScale *= -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoFondo : MonoBehaviour
{
    
    public int segs = 6;
    public bool tiempo;
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -1;
        tiempo = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire3") && segs == 6)
        {
            tiempo = false;
            CambiarFondo();
            Restando();
            Invoke("CambiarFondo2", 4f);

            if (tiempo == true) Invoke("Sumando", 10f);
        }
    }
    public void CambiarFondo()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 1;
    }
    public void CambiarFondo2()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -1;
    }
    
    public void Restando() 
    {
        segs = 0;
        tiempo = true;
    }
    public void Sumando()
    {
        segs = 6;
        
    }

    
}

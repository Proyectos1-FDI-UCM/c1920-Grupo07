using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoFondo : MonoBehaviour
{

    public int segs = 6;
    bool tiempo = false;
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -1;
    }

    void Update()
    {
        if (Input.GetButton("Fire3") && segs == 6)
        {
            tiempo = false;
            CambiarFondo();
            InvokeRepeating("CambiarFondo2", 4f, 0f);
            InvokeRepeating("Restando", 6f, 1f);
            InvokeRepeating("Sumando", 11f, 0f);
            if (tiempo == true) CancelInvoke();

        }
    }
    public void CambiarFondo()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = 10;
    }
    public void CambiarFondo2()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -1;
    }
    
    public void Restando()
    {
        if (segs < 7 && segs > 0)
        segs -= 1;
    }
    public void Sumando()
    {
        segs = 6;
        tiempo = true;
    }

    
}

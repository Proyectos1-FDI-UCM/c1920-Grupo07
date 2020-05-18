using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (GameManager.instance.CambioTiempo())
            {
                CambiarFondo();
                Invoke("CambiarFondo2", GameManager.instance.GetSegs() - 1);
            }
        }
        if (GameManager.instance.GetFondoTiempo())
        {
            CambiarFondo2();
            GameManager.instance.SetFondoTiempo(false);
        }
    }

    public void CambiarFondo()
    {
        sprite.sortingOrder = 0;
    }

    public void CambiarFondo2()
    {
        sprite.sortingOrder = -2;
        CancelInvoke();
    }  
}

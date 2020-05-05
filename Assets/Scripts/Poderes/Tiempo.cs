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
                Invoke("CambiarFondo2", GameManager.instance.GetSegs());
            }
        }
    }

    public void CambiarFondo()
    {
        sprite.sortingOrder = 1;
    }

    public void CambiarFondo2()
    {
        sprite.sortingOrder = -1;
        CancelInvoke();
    }  
}

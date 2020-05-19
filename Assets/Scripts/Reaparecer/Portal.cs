using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Animator anim;
    BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        anim = GetComponent<Animator>();
        box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.ActivaPortal())
        {
            box.enabled = true; 
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            anim.SetBool("AparecePortal", true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            GameManager.instance.Levelfinished();
            //Quitar cuando se acaben las pruebas
            GameManager.instance.SetCapsulasRest(GameManager.instance.GetCapsulasG() + 1);
            GameManager.instance.SetGravedad(false);
            GameManager.instance.GetSegs();
            GameManager.instance.ReiniciaMonedas();
            GameManager.instance.SetReapareceEnemigo(true);
            GameManager.instance.SetReaparecePuerta(true);
            GameManager.instance.AnulaMejoras();
            GameManager.instance.MuerteTiempo();
            GameManager.instance.SetFondoTiempo(true);
            GameManager.instance.SetIngredientes(0);
        }
    }
}

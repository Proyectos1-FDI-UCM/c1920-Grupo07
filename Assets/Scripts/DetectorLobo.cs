using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectorLobo : MonoBehaviour
{
    public bool iniciar = false;
    public GameObject Player, Lobo;
    public LoboAtaque LoboAtq;


    private void OnTriggerEnter2D(Collider2D Player)
    {

        iniciar = true;                                     // Activa todo el proceso del ataque del lobo.
        LoboAtq.anim.SetBool("Ataque", true);               // Activa la animación de ataque del lobo.


    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        iniciar = false;                                    // Desactiva todo el proceso del ataque del lobo.
        LoboAtq.anim.SetBool("Ataque", false);              // Desactiva la animación de ataque del lobo.
    }



}

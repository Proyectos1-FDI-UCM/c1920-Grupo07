using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLobo : MonoBehaviour
{
    public bool iniciar = false;
    [SerializeField] private LoboAtaque LoboAtq;

    private void OnTriggerEnter2D(Collider2D Player)        //  Inicia el movimiento del lobo en  
    {                                                       //  cuanto el jugador pasa por el detector.
        iniciar = true;    
    }

    private void Update()      //  Mira si el booleano está a true para iniciar el movimiento.
    {
        if (iniciar) LoboAtq.Invoke("Repeticion", 0.2f);
        
    }
}

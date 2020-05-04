using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLobo : MonoBehaviour
{
    public bool iniciar = false;
    [SerializeField] private LoboAtaque LoboAtq;

    private void OnTriggerEnter2D(Collider2D Player)
    {
        iniciar = true;    
    }

    private void Update()
    {
        if (iniciar) LoboAtq.Invoke("Repeticion", 0.2f);
    }
}

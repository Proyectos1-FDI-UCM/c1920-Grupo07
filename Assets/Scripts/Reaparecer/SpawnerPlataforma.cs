using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlataforma : MonoBehaviour
{
    ReaparecePlatPuerta[] componentes;
    private void Start()
    {
        componentes = transform.GetComponentsInChildren<ReaparecePlatPuerta>();
    }
    void Update()
    {
        if (GameManager.instance.GetReaparecePuerta())
        {
            
            foreach (ReaparecePlatPuerta comp in componentes)
            {
                comp.Reaparece();
                
            }

            GameManager.instance.SetReaparecePuerta(false);
        }
    }
}

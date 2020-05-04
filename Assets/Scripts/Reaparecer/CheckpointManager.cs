using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform ultCheckpoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reaparecer();
    }
    public void Pasapor(Transform checkpoint)
    {
        ultCheckpoint = checkpoint;
    }

    public void Reaparecer()
    {
        if (GameManager.instance.GetGravedad())
        {
            GameManager.instance.SetCapsulasRest(GameManager.instance.GetCapsulasG() + 1); //Poner una cápsula de más poruq econ la sig línea se resta una
            GameManager.instance.SetGravedad(false);
        }
        else
            GameManager.instance.SetCapsulasRest(GameManager.instance.GetCapsulasG());
               
        GameManager.instance.GetSegs();
        GameManager.instance.SetReapareceEnemigo(true);
        GameManager.instance.SetReaparecePuerta(true);
        transform.position = ultCheckpoint.position;
    }
    public void ReinicioTotal()
    {
        GameManager.instance.SetCapsulasRest(GameManager.instance.GetCapsulasG() + 1); //Poner una cápsula de más poruq econ la sig línea se resta una
        GameManager.instance.SetGravedad(false);
        GameManager.instance.GetSegs();
        GameManager.instance.ReiniciaMonedas();
        GameManager.instance.SetReapareceEnemigo(true);
        GameManager.instance.SetReaparecePuerta(true);
        GameManager.instance.AnulaMejoras();
        GameManager.instance.SetIngredientes(0);
    }
}

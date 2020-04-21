using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    //Se utiliza tambien para que las plataformas
    //vuelvan a su posicion inicial
    ReapareceEne[] componentes;
    private void Start()
    {
        componentes = transform.GetComponentsInChildren<ReapareceEne>();
    }
    void Update()
    {
        if (GameManager.instance.GetReapareceEnemigo())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(false);
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(true);
            }

            foreach (ReapareceEne comp in componentes)
                comp.Reaparece();
            GameManager.instance.SetReapareceEnemigo(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPuerta : MonoBehaviour
{
    // Para que las puertas vuelvan a su posicion

    
    Sprite normal;
    Transform child;
    void Start()
    {
        normal = GetComponent<SpriteRenderer>().sprite;
        child= transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetReapareceEnemigo())
        {
       
            child.gameObject.SetActive(false);      
            child.gameObject.SetActive(true);
            this.GetComponent<SpriteRenderer>().sprite = normal;
            child.GetComponent<ReapareceEne>().Reaparece();
            
        }
    }
}

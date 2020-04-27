using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaparecePlatPuerta : MonoBehaviour
{
    // Start is called before the first frame update
    RespawnPuerta componentes;
    Sprite normal;
    private void Start()
    {
        normal = GetComponent<SpriteRenderer>().sprite;
        componentes = transform.GetChild(0).GetComponent<RespawnPuerta>();
    }
    public void Reaparece()
    {

       
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normal;

        componentes.Reaparece();

    }
}

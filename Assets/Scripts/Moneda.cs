using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {            
            GameManager.instance.AddMonedas();
            Destroy(this.gameObject);
        }
    }
}

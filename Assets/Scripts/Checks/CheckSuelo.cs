using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSuelo : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)                  
            GameManager.instance.SetSuelo(true);        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)                 
            GameManager.instance.SetSuelo(false);        
    }    
}

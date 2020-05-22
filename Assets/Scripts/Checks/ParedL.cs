using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedL : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)        
            GameManager.instance.SetParedL(true);        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)        
            GameManager.instance.SetParedL(false);        
    }
}

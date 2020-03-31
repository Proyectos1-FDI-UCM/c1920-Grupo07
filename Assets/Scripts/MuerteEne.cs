using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEne : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            this.transform.parent.gameObject.SetActive(false);
        }
              
    }    
}

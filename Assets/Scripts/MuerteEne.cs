using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using UnityEngine;

public class MuerteEne : MonoBehaviour
{
    Rigidbody2D rb;
    private UnityEngine.Object DeathParticleRef;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        DeathParticleRef = Resources.Load("DeathParticle");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {       

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            this.transform.parent.gameObject.SetActive(false);
            GameObject DeathParticle = (GameObject)Instantiate(DeathParticleRef);
            DeathParticle.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        
    }    
}

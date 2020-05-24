using System.Security.Cryptography;
using UnityEngine;

public class MuerteEne : MonoBehaviour
{

    private Object DeathParticleRef;

    private void Start()
    {
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

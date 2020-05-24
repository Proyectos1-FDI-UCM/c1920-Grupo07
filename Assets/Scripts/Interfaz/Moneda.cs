using UnityEngine;

public class Moneda : MonoBehaviour
{    
    public SoundManager sonido;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {            
            GameManager.instance.AddMonedas(1);
            
            Destroy(this.gameObject);
            sonido.audMoneda.Play();

        }
    }
}

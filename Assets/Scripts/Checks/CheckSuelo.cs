using UnityEngine;

// Script para decir al gamemanager si el jugador se encuentra en el suelo
// Este script ira en un GameObject donde solo puede colisionar con el suelo
public class CheckSuelo : MonoBehaviour
{   
    // Si colisionas con un objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el otro objeto tiene el componente de CompositeCollider2D
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)                  
            GameManager.instance.SetSuelo(true);          // LLamamos al GameManager poniendo que esta tocando el suelo
    }

    // Al salir de la colision 
    private void OnTriggerExit2D(Collider2D other)
    {
        // Si el otro objeto tiene el componente de CompositeCollider2D
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)                 
            GameManager.instance.SetSuelo(false);        // LLamamos al GameManager poniendo que no esta tocando el suelo
    }    
}

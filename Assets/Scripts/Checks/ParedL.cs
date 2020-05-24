using UnityEngine;

// Script para decir al gamemanager si el jugador se encuentra en pegado a la pared izquierda
// Este script ira en un GameObject donde solo puede colisionar con la pared izquierda
public class ParedL : MonoBehaviour
{
    // Si colisionas con un objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el otro objeto tiene el componente de CompositeCollider2D
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)        
            GameManager.instance.SetParedL(true);        // LLamamos al GameManager poniendo que esta tocando la pared izquierda
    }

    // Al salir de la colision 
    private void OnTriggerExit2D(Collider2D other)
    {
        // Si el otro objeto tiene el componente de CompositeCollider2D
        if (other.gameObject.GetComponent<CompositeCollider2D>() != null)        
            GameManager.instance.SetParedL(false);        // LLamamos al GameManager poniendo que no esta tocando la pared izquierda
    }
}

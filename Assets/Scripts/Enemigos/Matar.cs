using UnityEngine;

public class Matar : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            other.gameObject.GetComponent<CheckpointManager>().Reaparecer();
            Debug.Log("HAS MUERTO");
        }
        else if (other.gameObject.GetComponent<MoverEne>() || other.gameObject.GetComponent<SaltoRana>())
            other.gameObject.SetActive(false);
    }
}

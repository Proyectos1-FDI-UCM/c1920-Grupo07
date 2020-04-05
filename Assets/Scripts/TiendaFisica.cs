using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaFisica : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.instance.SetTiendaFisica(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.instance.SetTiendaFisica(false);
        }
    }
}

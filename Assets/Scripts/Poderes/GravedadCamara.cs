using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadCamara : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<GravedadEne>())
        {
            other.gameObject.GetComponent<GravedadEne>().CambiarGravedad(GameManager.instance.GetGravedad());
        }
    }
}

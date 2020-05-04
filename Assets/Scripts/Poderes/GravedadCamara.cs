using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadCamara : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        GravedadEne gravedadEne = other.gameObject.GetComponent<GravedadEne>();
        if (gravedadEne) gravedadEne.CambiarGravedad(GameManager.instance.GetGravedad());        
    }
}

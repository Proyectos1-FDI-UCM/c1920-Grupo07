using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravedadCamara : MonoBehaviour
{
    private Collider2D miCollider;

    private void Start()
    {
        miCollider = GetComponent<Collider2D>();
        miCollider.enabled = true;
    }

    private void Update()
    {
        if(GameManager.instance.GetGravedad() == false)
        miCollider.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GravedadEne gravedadEne = other.gameObject.GetComponent<GravedadEne>();

        if (gravedadEne && GameManager.instance.GetGravedad() == true)
        {
            gravedadEne.CambiarGravedad();
            Invoke("DesactivarCollider", 0.2f);
        }
    }

    private void DesactivarCollider()
    {
        miCollider.enabled = false;
    }
}

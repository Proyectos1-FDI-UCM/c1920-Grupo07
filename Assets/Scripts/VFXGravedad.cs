using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXGravedad : MonoBehaviour
{
    public Animator anim;
    SoundManager audioSrc;
    SoundManager Gravedad;
    
    void Update()
    {
        if (GameManager.instance.GetGravedad())
        {
            
            anim.SetBool("Gravedad", true);
            anim.SetBool("Gravedad2", false);
           
        }
        else
        {
            
            anim.SetBool("Gravedad", false);
            anim.SetBool("Gravedad2", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.instance.GetCapsulasRest() > 0 && !GameManager.instance.GetEscalera())
            SoundManager.PlaySound("Gravedad");
    }
}

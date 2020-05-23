using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararAnimacion : MonoBehaviour
{    
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()       //  Detiene las animaciones dependiendo
                                //  de si se ha parado el tiempo o no.
    {
        if (GameManager.instance.Tiempo())        
            anim.SetBool("Parado", true);
        
        else
            anim.SetBool("Parado", false);
    }
}

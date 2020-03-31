using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararAnimacion : MonoBehaviour
{    
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (GameManager.instance.Tiempo())        
            anim.SetBool("Parado", true);
        
        else
            anim.SetBool("Parado", false);
    }
}

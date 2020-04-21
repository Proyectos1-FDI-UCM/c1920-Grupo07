using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    private bool pasado = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null && !pasado)
        {
            pasado = true;
            other.GetComponent<CheckpointManager>().Pasapor(this.transform);
            anim.SetBool("Check", true);
            GameManager.instance.SetCapsulasRest(GameManager.instance.GetCapsulasG());
        }
    }
}

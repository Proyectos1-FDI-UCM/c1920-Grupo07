using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public bool aNivel1, aTiempo;
    public AudioSource audNivel1, audTiempo, audGravedad;


    void Start()
    {
        GameManager.instance.SetSoundManager(this); //  Comprobar que solo hay un SoundManager
        audioNivel();
    }
  
    public void audioGravedad()
    {
        audGravedad.Play();
    }


    public void audioNivel()
    {
        aNivel1 = true;
        aTiempo = false;
        audNivel1.Play();
    }

    public void audioTiempo()
    {
        if (audNivel1.isPlaying)
            aNivel1 = false;
        {
            audNivel1.Stop();
        }
        if (!audTiempo.isPlaying && aTiempo == false)
        {
            audTiempo.Play();
            aTiempo = true;
        }
        Invoke("audioNivel", GameManager.instance.GetSegs());

    }
  
}

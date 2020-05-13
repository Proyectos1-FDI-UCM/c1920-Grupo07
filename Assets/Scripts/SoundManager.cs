using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public bool aNivel1, aTiempo;       //  Booleanos que sirven para controlar el audio que suena cuando paras el tiempo.
    public AudioSource audNivel1, audTiempo, audGravedad, audLobo, audLoboM, audRana, audRanaM, audAve, audAveM;   //  Lista de los audios 
    public GameObject Rana, Lobo, Ave;


    void Start()
    {
        GameManager.instance.SetSoundManager(this); //  Comprobar que solo hay un SoundManager.
        audioNivel();                               //  Iniciar la música del nivel 1.

     //  Convierto los audioSources en hijos desde el script para tener ordenados los audios en la jerarquía.
        audRana.transform.parent = Rana.transform;  //  Convierte el audioSource de la rana en hijo del GameObject Rana.
        audLobo.transform.parent = Lobo.transform;  //  Convierte el audioSource del lobo en hijo del GameObject Lobo.
        audAve.transform.parent = Ave.transform;    //  Convierte el audioSource del ave en hijo del GameObject Ave.
    }

    public void deadRana()          //  Método que detiene el croak de la rana  
    {                               //  para reproducir un efecto sonoro de muerte.
        audRana.Stop();
        audRanaM.Play();

    }

    public void deadLobo()
    {
        audLobo.Stop();
        audLoboM.Play();
    }

    public void deadAve()
    {
        audAve.Stop();
        audAveM.Play();
    }
       

    public void audioNivel()        //  Método, junto a audioTiempo(), que sirve para
    {                               //  reproducir de manera correcta la música de cuando
        aNivel1 = true;             //  se para el tiempo.
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

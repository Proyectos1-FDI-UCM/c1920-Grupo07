using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // Aquí se declaran los archivos de sonido que tenemos como variables para poder usarlos en el código.
    public static AudioClip Gravedad;

    // El componente del inspector que va a manejar los sonidos.
    public static AudioSource audioSrc;

    void Start()
    {
        // Es importante que la carpeta en la que estén los sonidos se llame Resources, ya que sino no lo busca.
        
        Gravedad = Resources.Load<AudioClip>("SonidoGravedad");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.1f;

    }

  
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Gravedad":
                
                audioSrc.PlayOneShot(Gravedad);
                break;
        }
    }
}

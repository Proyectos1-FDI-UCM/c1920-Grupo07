using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinsText;
    public Image[] capsulasLlenas;
    public Image[] partesIngrdientes;
    public Image barraTiempo;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
        UpdateMonedas(0);
        capsulasLlenas[6].enabled = false;
        capsulasLlenas[7].enabled = false;
        capsulasLlenas[8].enabled = false;   //Para las vacías
        capsulasLlenas[9].enabled = false;
    }

    public void UpdateMonedas(int monedas) //Actualizar puntos
    {
        coinsText.text = monedas.ToString();
    }

    public void UpdateGravedad(int capsulasG)
    {
        int c = capsulasG - 1;

        if (capsulasG < GameManager.instance.GetCapsulasG())
            capsulasLlenas[capsulasG].enabled = false;
        else if (capsulasG == GameManager.instance.GetCapsulasG())
        {
            for (int i = 0; i <= c; i++)
                capsulasLlenas[c - i].enabled = true;
        }
    }

    public void TiendaGravedad()
    {
        for (int i = 0; i <= 9; i++)        //Hacer 10 vueltas por las dos nuevas que están vacías
            capsulasLlenas[i].enabled = true;
    }

    public void UpdateTiempo(int seg, bool tiendaT)
    {
        if (tiendaT)
        {
            barraTiempo.fillAmount = seg * 0.14f;
            Debug.Log(barraTiempo.fillAmount);
        }

        else
        {
            barraTiempo.fillAmount = seg * 0.2f;    // 1/seg
            Debug.Log(barraTiempo.fillAmount);
        }
            
    }

    public void UpdateIngredientes(int numero)
    {
        partesIngrdientes[numero].enabled = false;        
    }
}

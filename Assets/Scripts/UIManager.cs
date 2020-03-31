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
    }

    public void UpdateMonedas(int monedas) //Actualizar puntos
    {
        coinsText.text = monedas.ToString();
    }

    public void UpdateGravedad(int capsulasG)
    {
        int c = capsulasG-1;

        if(capsulasG < 6)
            capsulasLlenas[capsulasG].enabled = false;
        else if( capsulasG == 6)
        {
            for (int i = 0; i <= c; i++)
                capsulasLlenas[c-i].enabled = true;
        }
    }

    public void UpdateTiempo(int seg)
    {               
        barraTiempo.fillAmount = seg * 0.2f;
    }

    public void UpdateIngredientes(int numero)
    {
        partesIngrdientes[numero].enabled = false;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Image[] capsulasLlenas;
    [SerializeField] private Image[] partesIngrdientes;
    [SerializeField] private Image barraTiempo;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
        UpdateMonedas(0);
        for (int i = 6; i<= 9; i++) capsulasLlenas[i].enabled = false;    //Para las vacías
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
            if (barraTiempo != null)
                barraTiempo.fillAmount = seg * 0.14f;
            Debug.Log(barraTiempo.fillAmount);
        }

        else
        {
            if(barraTiempo != null)
                barraTiempo.fillAmount = seg * 0.2f;    // 1/seg
            Debug.Log(barraTiempo.fillAmount);
        }            
    }

    public void RellenaBarraTiempo()
    {
        barraTiempo.fillAmount = 1;
    }

    public void UpdateIngredientes(int numero)
    {
        partesIngrdientes[numero].enabled = false;        
    }
}

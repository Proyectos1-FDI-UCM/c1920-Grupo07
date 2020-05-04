using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaManager : MonoBehaviour
{
    public int mejoraG = 0;
    public int mejoraT = 0; 
    public Text mejoraGrav;
    public Text mejoraTiempo;
    public Image[] capsulasLlenasG;
    public Image[] capsulasLlenasT;

    private Canvas tiendaUI;
    private void Start()
    {
        tiendaUI = GetComponent<Canvas>();
        tiendaUI.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.GetTiendaFisica())
        {
            if (tiendaUI.enabled)
                tiendaUI.enabled = false;
            else
                tiendaUI.enabled = true;
        }
    }
   
    public void TiendaGravedad()
    {
        if (GameManager.instance.GetMonedas() >= 10 && mejoraG != 3)
        {
            mejoraG += 1;
            GameManager.instance.AddMonedas(-10);
            CompraG();
        }       
            
        
        if (mejoraG == 3)
        {
            GameManager.instance.ActualizaTienda();
            GameManager.instance.SetCapsulasRest(8);
            GameManager.instance.SetTiendaG(true);            
        }       
    }

    public void TiendaTiempo()
    {
        if (GameManager.instance.GetMonedas() >= 10 && mejoraT != 3)
        {
            mejoraT += 1;
            GameManager.instance.AddMonedas(-10);
            CompraT();
        }
        if (mejoraT == 3)
        {
            GameManager.instance.SetSegs(7);
            GameManager.instance.SetTiendaT(true);
            GameManager.instance.UpdateTiempo();
        }
    }

    private void CompraG()
    {
        int n = mejoraG;
        capsulasLlenasG[n - 1].enabled = true;
        mejoraGrav.text = n.ToString() + "/3";
    }

    private void CompraT()
    {
        int n = mejoraT;
        capsulasLlenasT[n - 1].enabled = true;
        mejoraTiempo.text = n.ToString() + "/3";
    }
}

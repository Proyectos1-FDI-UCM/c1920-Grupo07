using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaManager : MonoBehaviour
{
    [SerializeField] private int mejoraG = 0;
    [SerializeField] private int mejoraT = 0;
    [SerializeField] private int precio = 10;
    [SerializeField] private Text mejoraGrav;
    [SerializeField] private Text mejoraTiempo;
    [SerializeField] private Image[] capsulasLlenasG;
    [SerializeField] private Image[] capsulasLlenasT;

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
        if (GameManager.instance.GetMonedas() >= precio && mejoraG != 3)
        {
            mejoraG += 1;
            GameManager.instance.AddMonedas(-precio);
            CompraG();
        }               
        if (mejoraG == 3)
        {
            GameManager.instance.ActualizaTienda();
            GameManager.instance.SetCapsulasRest(8);        //poner la cte
            GameManager.instance.SetTiendaG(true);            
        }       
    }

    public void TiendaTiempo()
    {
        if (GameManager.instance.GetMonedas() >= precio && mejoraT != 3)
        {
            mejoraT += 1;
            GameManager.instance.AddMonedas(-precio);
            CompraT();
        }
        if (mejoraT == 3)
        {
            GameManager.instance.SetSegs(7);          //poner la cte
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

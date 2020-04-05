using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    public Text mejoraG;
    public Text mejoraT;
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
    public void CompraG()
    {
        int n = GameManager.instance.TiendaGravedad();
        capsulasLlenasG[n-1].enabled = true;
        mejoraG.text = n.ToString() + "/3";
    }

    public void CompraT()
    {
        int n = GameManager.instance.TiendaTiempo();
        capsulasLlenasT[n-1].enabled = true;
        mejoraT.text = n.ToString() + "/3";
    }
}

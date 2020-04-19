using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager theUIManager;


    const int SEGS = 5;
    const int SEGSMEJORADO = 7;
    const int CAPS = 6;
    const int CAPSMEJORADO = 8;

    private int partesIngrediente = 0;
    public int segs = 5;
    public int monedas = 0;
    private int capsulasG = 6;
   

    private bool gravedad = false;
    private bool tiempo = false;
    private bool escalera = false;
    private bool reapareceEne = false;
    public bool tiendaG = false;
    public bool tiendaT = false;
    public bool tiendaFisica = false;

    private bool suelo;
    private bool paredL;
    private bool paredR;
    
    void Awake() // Comprobar que solo hay un GameManager
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else Destroy(this.gameObject);
    }

    public void SetSuelo(bool isGrounded)
    {
        suelo = isGrounded;
    }

    public bool GetSuelo()
    {
        return suelo;
    }

    public void SetParedL(bool paredL_)
    {
        paredL = paredL_;
    }

    public bool GetParedL()
    {
        return paredL;
    }

    public void SetParedR(bool paredR_)
    {
        paredR = paredR_;
    }

    public bool GetParedR()
    {
        return paredR;
    }

    public void AddMonedas(int n)
    {
        monedas += n;
        if (theUIManager != null)
            theUIManager.UpdateMonedas(monedas);
        Debug.Log(monedas);
    }

    public void ReiniciaMonedas()
    {
        monedas = 0;
        if (theUIManager != null)
            theUIManager.UpdateMonedas(monedas);
    }

    public int GetMonedas()
    {
        return monedas;
    }

    public int GetSegs()
    {
        if (!tiendaT)
            return SEGS;
        
        else
            return SEGSMEJORADO;        
    }
    public void SetSegs(int s)
    {
        segs = s;
    }

    public void CambioTiempo()
    {
        if (segs == GetSegs())
        {
            tiempo = !tiempo;      //Invierte tiempo y lo vuelve a invertir después de 5 segundos                       
            InvokeRepeating("Crono", 0f, 1f);
        }
    }

    public void Crono()
    {
        segs -= 1;
        theUIManager.UpdateTiempo(segs,tiendaT);
        if (segs == 0)
        {
            tiempo = false;
            CancelInvoke();
            InvokeRepeating("RecuperarTiempo", 1f, 1.5f);
        }
    }

    public void RecuperarTiempo()
    {
        if (segs != GetSegs())
        {
            segs += 1;
            theUIManager.UpdateTiempo(segs,tiendaT);
        }
        if (segs == GetSegs())
            CancelInvoke();
    }

    public bool Tiempo()
    {
        return tiempo;
    }

    public void SetGravedad(bool active) //Método que recoge booleano del script Gravedad para saber el estado
    {
        gravedad = active;
        SetCapsulasRest(capsulasG - 1);
        theUIManager.UpdateGravedad(capsulasG);
        Debug.Log("CAPSULAS RESTANTES: " + capsulasG);
    }

    public bool GetGravedad() //Método que devuelve el booleano pedido en el método de SetGravedad
    {
        return gravedad;
    }

    public void SetCapsulasRest(int capsG)
    {
        capsulasG = capsG;
        theUIManager.UpdateGravedad(capsulasG);
    }

    public int GetCapsulasRest()
    {
        return capsulasG;
    }

    public void SetEscalera(bool escalera1)
    {
        escalera = escalera1;
    }

    public bool GetEscalera()
    {
        return escalera;
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName != "")    //Para botón reanudar
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            tiempo = false;
            gravedad = false;
            escalera = false;
        }
        Time.timeScale = 1;
    }

    public void RecogeIngrediente(int nIngr)
    {
        partesIngrediente++;
        theUIManager.UpdateIngredientes(nIngr);        
    }

    public bool ActivaPortal()
    {

        return (partesIngrediente == 4);

        

    }

    public void Levelfinished()
    {
        if (partesIngrediente == 4&& SceneManager.GetActiveScene().name=="Nivel1")
        {
            ChangeScene("Nivel2");
        }
        else if (partesIngrediente == 4 && SceneManager.GetActiveScene().name == "Nivel2")
        {
            ChangeScene("Nivel3");
        }
        else if (partesIngrediente == 4 && SceneManager.GetActiveScene().name == "Nivel3")
        {
            ChangeScene("Nivel4");
        }

        partesIngrediente = 0;
    }
    public void SetUIManager(UIManager uim) // Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
        theUIManager.UpdateMonedas(monedas);
        theUIManager.UpdateGravedad(capsulasG);
        theUIManager.UpdateTiempo(GetSegs(),tiendaT);
    }

    public void SetReapareceEnemigo(bool _reapareceEne)
    {
        reapareceEne = _reapareceEne;
    }

    public bool GetReapareceEnemigo()
    {
        return reapareceEne;
    }
    public int GetCapsulasG()
    {
        if (!tiendaG)
            return CAPS;
        else
            return CAPSMEJORADO;
    }
    public void SetTiendaFisica(bool tiendaF)
    {
        tiendaFisica = tiendaF;
    }

    public bool GetTiendaFisica()
    {
        return tiendaFisica;
    }

    public void ActualizaTienda()
    {
        theUIManager.TiendaGravedad();
    }

    public void UpdateTiempo()
    {
        theUIManager.UpdateTiempo(segs,tiendaT);
    }

    public void SetTiendaG(bool tiendaG_)
    {
        tiendaG = tiendaG_;
    }

    public void SetTiendaT(bool tiendaT_)
    {
        tiendaT = tiendaT_;
    }

    public void AnulaMejoras()
    {
        tiendaG = false;
        tiendaT = false;
        segs = SEGS;
        /*mejoraG = 0;
        mejoraT = 0;*/
    }
}

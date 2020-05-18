using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    UIManager theUIManager;
    SoundManager soundManager;

    const int SEGS = 5;
    const int SEGSMEJORADO = 7;
    const int CAPS = 6;
    const int CAPSMEJORADO = 8;

    public int partesIngrediente = 0;
    public int segs = 5;
    public int monedas = 0;
    public int capsulasG = 6;

    bool fondo = false;
    bool reaparecePuerta = false;
    public bool gravedad = false;
    private bool tiempo = false;
    private bool escalera = false;
    private bool reapareceEne = false;
    public bool tiendaG = false;
    public bool tiendaT = false;
    public bool tiendaFisica = false;

    private bool suelo;
    private bool paredL;
    private bool paredR;

    void Awake()                                    //  Comprobar que solo hay un GameManager.
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else Destroy(this.gameObject);
    }

    public void SetSuelo(bool isGrounded)       //  Detecta el suelo. 
    {
        suelo = isGrounded;
    }

    public bool GetSuelo()                      //  Devuelve un valor que indica
    {                                           //  si hay suelo o no.
        return suelo;
    }

    public void SetParedL(bool paredL_)         //  Detecta pared por la izquierda.
    {
        paredL = paredL_;
    }

    public bool GetParedL()                     //  Devuelve un valor que indica
    {                                           //  si hay pared por la izquierda o no.
        return paredL;
    }

    public void SetParedR(bool paredR_)         //  Detecta pared por la derecha.
    {
        paredR = paredR_;
    }

    public bool GetParedR()                     //  Devuelve un valor que indica
    {                                           //  si hay pared por la derecha o no.
        return paredR;
    }

    public void AddMonedas(int n)               //  Añade monedas a la cantidad actual.
    {
        monedas += n;
        if (theUIManager != null)
            theUIManager.UpdateMonedas(monedas);
        Debug.Log(monedas);
    }

    public void ReiniciaMonedas()               //  Pone la cantidad de monedas a 0.
    {
        monedas = 0;
        if (theUIManager != null)
            theUIManager.UpdateMonedas(monedas);
    }

    public int GetMonedas()                     //  Devuelve la cantidad de monedas.
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

    public bool CambioTiempo()
    {
        if (segs == GetSegs())
        {
            soundManager.audioTiempo();
            tiempo = !tiempo;                            // Invierte tiempo y lo vuelve a invertir después de 5 segundos                       
            InvokeRepeating("Crono", 0f, 1f);
            return true;
        }
        else return false;
    }
    public void SetFondoTiempo(bool _fondo)
    {
        fondo = _fondo;
    }
    public bool GetFondoTiempo()
    {
        return fondo;
    }
    public void MuerteTiempo()
    {
        CancelInvoke();
        tiempo = false;
        segs = GetSegs();
        theUIManager.RellenaBarraTiempo();
        soundManager.ResetNivel();
        
    }
    public void Crono()
    {
        segs -= 1;
        theUIManager.UpdateTiempo(segs, tiendaT);
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
            theUIManager.UpdateTiempo(segs, tiendaT);
        }
        if (segs == GetSegs())
            CancelInvoke();
    }

    public bool Tiempo()                //  Devuelve un valor que indica 
    {                                   //  si el tiempo está detenido o no.
        return tiempo;
    }

    public void SetGravedad(bool active)            //  Método que recoge booleano del script Gravedad para saber el estado.
    {
        gravedad = active;
        SetCapsulasRest(capsulasG - 1);
        theUIManager.UpdateGravedad(capsulasG);
        Debug.Log("CAPSULAS RESTANTES: " + capsulasG);
    }

    public bool GetGravedad()                       //  Método que devuelve el booleano pedido en el método de SetGravedad.
    {
        return gravedad;
    }

    public void SetCapsulasRest(int capsG)          //  Da un valor a la cantidad de cápsulas. 
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

    public bool GetEscalera()               //  Devuelve un valor que indica 
    {                                       //  si hay escalera o no.
        return escalera;
    }

    public bool GetReaparecePuerta()
    {
        return reaparecePuerta;
    }

    public void SetReaparecePuerta(bool _reaparecePuerta)
    {
        reaparecePuerta = _reaparecePuerta;
    }

    public void ChangeScene(string sceneName)        //  Cambia de la escena actual a otra.
    {
        if (sceneName != "")                         //  Para el botón reanudar.
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            tiempo = false;
            gravedad = false;
            escalera = false;
        }
        Time.timeScale = 1;
    }

    public void RecogeIngrediente(int nIngr)         //  Añade 1 a la cantidad de 
    {                                                //  ingredientes actuales.
        partesIngrediente++;
        theUIManager.UpdateIngredientes(nIngr);
    }

    public void SetIngredientes(int n)               //  Da un valor a la cantidad de ingredientes.
    {
        partesIngrediente = n;
    }
    public bool ActivaPortal()                      //  Activa el portal al siguiente 
    {                                               //  nivel en caso de que haya 4 ingredientes.
        return (partesIngrediente == 4);
    }

    public void Levelfinished()
    {
        if (partesIngrediente == 4 && SceneManager.GetActiveScene().name == "Nivel1")
        {
            ChangeScene("FinDemo"); //Cambiar a "Nivel2"
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
    public void SetUIManager(UIManager uim)          //  Comprobar solo un UI y actualizarlo
    {
        theUIManager = uim;
        theUIManager.UpdateMonedas(monedas);
        theUIManager.UpdateGravedad(capsulasG);
        theUIManager.UpdateTiempo(GetSegs(), tiendaT);
    }

    public void SetSoundManager(SoundManager sm)
    {
        soundManager = sm;
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
        theUIManager.UpdateTiempo(segs, tiendaT);
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
    }
}

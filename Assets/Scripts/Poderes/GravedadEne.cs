using UnityEngine;

public class GravedadEne : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool miGravedad = false;

    void Start()    //  Declara una variable que recoge el componente Rigidbody2D
    {               //  del GameObject al que esté asociado el script.

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(GameManager.instance.GetGravedad() == false && miGravedad != GameManager.instance.GetGravedad())      //  Accede al rigidbody y cambia su gravedad.
        {
            rb.gravityScale *= -1;
            transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            miGravedad = !miGravedad;
        }
    }

    public void CambiarGravedad()
    {
        if(GameManager.instance.GetGravedad() != miGravedad && GameManager.instance.GetGravedad() == true)        //  Vuelve a cambiar su gravedad.
        {
            rb.gravityScale *= -1;
            transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
            miGravedad = !miGravedad;
        }
    }
}

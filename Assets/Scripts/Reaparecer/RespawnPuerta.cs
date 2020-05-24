using UnityEngine;

public class RespawnPuerta : MonoBehaviour
{
    // Para que las puertas vuelvan a su posicion

    Vector2 posIni;
    void Start()
    {
        posIni = new Vector2(transform.position.x, transform.position.y);

    }

    public void Reaparece()
    {
        transform.position = posIni;

    }
}

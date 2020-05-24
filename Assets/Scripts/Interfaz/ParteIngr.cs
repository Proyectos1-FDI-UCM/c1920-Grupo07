using UnityEngine;

public class ParteIngr : MonoBehaviour
{
    public int nIngr;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.instance.RecogeIngrediente(nIngr);
            Destroy(this.gameObject);
        }
    }
}

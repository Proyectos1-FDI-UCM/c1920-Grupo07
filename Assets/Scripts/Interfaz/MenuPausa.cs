using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    private Canvas MenuPausaUI;

    private void Start()
    {
        MenuPausaUI = GetComponent<Canvas>();
        MenuPausaUI.enabled = false;
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuPausaUI.enabled)            
                Reanudar();  
            else            
                Pausa();            
        }
    }

    public void Reanudar()
    {
        MenuPausaUI.enabled = false;
        Time.timeScale = 1.0f;     
    }

    private void Pausa()
    {      
        MenuPausaUI.enabled = true;
        Time.timeScale = 0f;       
    }
}

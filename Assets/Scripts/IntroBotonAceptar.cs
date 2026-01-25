using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroBotonAceptar : MonoBehaviour
{
    
    public TMP_InputField nombreInput;

    public void Aceptar()
    {
        //Guardamos el nombre en PlayerPrefs    
        PlayerPrefs.SetString("NombreJugador", nombreInput.text);

        //Cambiamos de escena
        SceneManager.LoadScene("Laberinto");
        
               
    }
    
    
    
    
    
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

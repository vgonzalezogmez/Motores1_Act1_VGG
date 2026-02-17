using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void SalirDelJuego()
    {
        // Cierra la aplicación instalada
        Application.Quit();

        // Esto solo es para que veas que funciona mientras pruebas en Unity
        Debug.Log("El juego se ha cerrado");
        
        // (Opcional) Si estás en el editor de Unity, esto detiene el Play Mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // 
    }
}

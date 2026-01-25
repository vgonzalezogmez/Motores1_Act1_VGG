using UnityEngine;
using UnityEngine.SceneManagement;
public class ReiniciarJuego : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
 
    public void Restartgame()
    {
        
        SceneManager.LoadScene("Intro");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

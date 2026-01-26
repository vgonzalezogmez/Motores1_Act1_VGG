using UnityEngine;
using UnityEngine.SceneManagement;
public class GanarJuego : MonoBehaviour
{
       
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("dentro de la salida");
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("GanarJuego");
        }
    }
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

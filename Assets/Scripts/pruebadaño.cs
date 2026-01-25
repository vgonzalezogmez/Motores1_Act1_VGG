using UnityEngine;
using UnityEngine.InputSystem;

public class pruebadaño : MonoBehaviour
{

    [SerializeField] VidaPlayer vida;
    [SerializeField] int daño;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            
            Debug.Log("voy a recibir daño");
            vida.recibirDaño();
        }
    }
}

using TMPro;
using UnityEngine;

public class RecuperarNombrePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public TextMeshProUGUI nombrePlayer;

    void Start()
    {

        //recuperar el texto guardado y asignarlo
        nombrePlayer.text=PlayerPrefs.GetString("NombreJugador","Player");
        

    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}

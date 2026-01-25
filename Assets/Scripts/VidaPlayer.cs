using System;
using System.Linq;

//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;


public class VidaPlayer : MonoBehaviour
{

    public int maxVida = 3;
    public int vidaActual;

    public Image[] vidasUI; //asignamos las imagenes desde el inspector


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = maxVida;

        //actualizarUI();

    }

    private void actualizarUI()
    {

        //Debug.Log(vidasUI.Length);
        //Debug.Log("dentro del for"+ vidasUI.Length);
        //vidasUI[vidaActual].enabled = false;
                  
    }

    public void recibirDaño()
    {

        vidaActual--;

        if (vidaActual<=0)
        {
            vidasUI[vidaActual].enabled = false;
            //se acaba el juego
            gameover();
        }
        else
        {

            //actualizarUI();    
            vidasUI[vidaActual].enabled = false;
        }
        
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trampa"))
        {
            recibirDaño();
        }
    }

    private void gameover()
    {
        // mostrar canva de game over y reiniciar laberinto
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

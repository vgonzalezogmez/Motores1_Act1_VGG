using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MovimientoPersonaje : MonoBehaviour
{
    
    //Variables para controlar la velocidad de moviemiento y de rotacion del personaje
    public float velocidadGiro = 300.0f;
    public float velocidadAvance = 7.0f;

    public bool sufredaño = false;

    // Referencia al CharacterController 
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // Obtenemos el componente al iniciar
        controller = GetComponent<CharacterController>();
    }
       
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        moviemiento();
                

        
    }


    void moviemiento()
    {
         // 1. Obtener Inputs del jugador 
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // 2. Calcular y aplicar el Giro (Rotate) 
        // Usamos Time.deltaTime para suavizar el movimiento independiente de los FPS 
        float rotacion = movimientoHorizontal * velocidadGiro * Time.deltaTime;
        transform.Rotate(0, rotacion, 0);

        // 3. Calcular el Avance
        // El personaje avanza hacia donde mira (Vector3.forward)
        // Multiplicamos por la velocidad, el input y el tiempo 
        Vector3 avance = transform.forward * movimientoVertical * velocidadAvance * Time.deltaTime;

        // 4. Transformar de Local Space a World Space [
        // Esto es crucial: convierte "adelante relativo a mí" en "coordenadas del mundo"
        //Vector3 movimiento = transform.TransformDirection(avance);

        // 5. Mover el CharacterController 
        // Aquí es donde aplicamos el movimiento final
        controller.Move(avance);

    }

    
    public void AddKnockback(Vector3 direction, float distancia, float tiempo)
    {
        if (sufredaño == false)
        {
            StartCoroutine(rutinaRetroceso(direction,distancia,tiempo));
        }
        
    }

    public IEnumerator rutinaRetroceso(Vector3 direction, float distancia, float tiempo)
    {
        sufredaño=true;
        float timer=0;

        direction.y=0;
        direction.Normalize();

        while (timer< tiempo)
        {
            float moveback =(distancia/tiempo) * Time.deltaTime;
            controller.Move(direction * moveback);
            tiempo+=Time.deltaTime;
            yield return null;
        }

        sufredaño=false;

    }

}

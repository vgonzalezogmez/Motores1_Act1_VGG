using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    //Variables para controlar la velocidad de moviemiento y de rotacion del personaje
    public float velocidadGiro = 100.0f;
    public float velocidadAvance = 6.0f;

    // Referencia al CharacterController [cite: 14, 32]
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtenemos el componente al iniciar
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Obtener Inputs del jugador [cite: 22, 23]
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // 2. Calcular y aplicar el Giro (Rotate) [cite: 26]
        // Usamos Time.deltaTime para suavizar el movimiento independiente de los FPS [cite: 28]
        float rotacion = movimientoHorizontal * velocidadGiro * Time.deltaTime;
        transform.Rotate(0, rotacion, 0);

        // 3. Calcular el Avance
        // El personaje avanza hacia donde mira (Vector3.forward) [cite: 27]
        // Multiplicamos por la velocidad, el input y el tiempo [cite: 25, 29]
        Vector3 avance = Vector3.forward * movimientoVertical * velocidadAvance * Time.deltaTime;

        // 4. Transformar de Local Space a World Space [cite: 30, 31]
        // Esto es crucial: convierte "adelante relativo a mí" en "coordenadas del mundo"
        Vector3 movimiento = transform.TransformDirection(avance);

        // 5. Mover el CharacterController 
        // Aquí es donde aplicamos el movimiento final
        controller.Move(movimiento);

    }
}

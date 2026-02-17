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

/**
using UnityEngine;

public class MovimientoPlayer2D : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    private PlayerControls controls;
    private Vector3 direccion;
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    void Update()
    {
        // Leemos el valor del Input (solo nos interesa el eje X)
        direccion = controls.Player.Move.ReadValue<Vector3>();

        // Aplicamos el movimiento al transform del padre
        transform.Translate(new Vector3(direccion.x, 0, 0) * velocidad * Time.deltaTime);
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayer3D : MonoBehaviour
{
    //este scrip mueve el player alante atra sobre eje x e y.

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference jump;

    [SerializeField] float speed =5f;

    Vector2 rawMove = Vector2.zero;

    private void OnEnable()
    {
        //esto hace que escuche 
        move.action.Enable(); 


        //que tiene que hacer 
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

    }

    private void OnDisable()
    {
        //esto hace que escuche 
        move.action.Disable(); 


        //que tiene que hacer 
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;
      
      
    }

    //metodo propio para OnMove que usa inputaction.callbackcontext
    void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        Debug.Log(rawMove);

    }

    void MovePlayer()
    {
        Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * speed * Time.deltaTime;
        transform.Translate(moveToApply);
    }

    void Update()
    {
        MovePlayer();
    }
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayer3Dcongiro : MonoBehaviour
{
    //este script mueve el player alante atra sobre y y lo rota sobre eje x

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference jump;

    [SerializeField] float speed =5f;

    [SerializeField] float rotationSpeed =100f; //grados por segundo

    Vector2 rawMove = Vector2.zero;

    private void OnEnable()
    {
        //esto hace que escuche 
        move.action.Enable(); 


        //que tiene que hacer 
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

    }

    private void OnDisable()
    {
        //esto hace que escuche 
        move.action.Disable(); 


        //que tiene que hacer 
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;
      
      
    }

    //metodo propio para OnMove que usa inputaction.callbackcontext
    void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        Debug.Log(rawMove);

    }
    

    void MovePlayer()
    {
        // Solo usamos el eje Y del rawMove (W y S) para avanzar o retroceder
        // Usamos transform.forward para que siempre avance hacia donde mira
        Vector3 direction = transform.forward * rawMove.y;
        transform.position += direction * speed * Time.deltaTime;

        //MOVIMIENTO SIN GIRO
        //Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * speed * Time.deltaTime;
        //transform.Translate(moveToApply);
    }
    void RotatePlayer()
    {
        // Usamos el eje X del rawMove (A y D) para rotar sobre sí mismo
        float rotationAmount = rawMove.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0,rotationAmount,0);
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    using UnityEngine;

public class Obstaculo : MonoBehaviour
{
     public float puntuacionsuma;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    float puntuacion =0;
    public TextMeshProUGUI textopuntuacion;



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Obstaculo obstaculoOBJ = collision.gameObject.GetComponent<Obstaculo>();
            
            puntuacion += obstaculoOBJ.puntuacionsuma;
            
            textopuntuacion.text= "PUNTUACION:" + " " + puntuacion.ToString();

           //Debug.Log(puntuacion);
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    using UnityEngine;

public class ImpulsoExtra : MonoBehaviour
{
    [SerializeField] float fuerzaImpulso = 2f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        // Comprobamos si chocamos con una pelota roja (asegúrate de que tengan el Tag "Obstaculo")
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("colision detectada" + collision.gameObject.tag);
            // Calculamos una dirección aleatoria hacia los lados y arriba
            Vector3 direccionAleatoria = new Vector3(Random.Range(-1f, 1f), 0.5f,0).normalized;// Un pequeño impulso hacia arriba para que no caiga tan rápido
                  
            // Aplicamos el impulso
            rb.AddForce(direccionAleatoria * fuerzaImpulso, ForceMode.Impulse);
        }
    }
}
using UnityEngine;

public class AddVelocity : MonoBehaviour
{
   [SerializeField] float impulse = -10f;
   [SerializeField] ForceMode mode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,impulse,0),mode);
    }

    
}

**/

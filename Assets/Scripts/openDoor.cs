using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class openDoor : MonoBehaviour
{



[SerializeField] float radius   =1f;
[SerializeField] Canvas detectedCanvas;
public LayerMask _lm;
public Animator animatorDoor;


    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        bool doorDetected=false;
        string lname="";

        for (int i=0; i < colliders.Length; i++)
        {
            //Debug.Log("for obj "+colliders[i].gameObject.name);

            //Debug.Log(colliders[i].gameObject.layer == 3);
            //Debug.Log(colliders[i].gameObject.layer);
            // if (colliders[i].gameObject.layer == LayerMask.NameToLayer("botonpuerta"))
           /* if(((1<<colliders[i].gameObject.layer) & _lm ) !=0) 
            {
                
                //Debug.Log("hay un boton de abrir puerta cerca");
                doorDetected=true;
                lname=colliders[i].gameObject.tag;
                Debug.Log("dentro del if");
                if (Keyboard.current.eKey.isPressed)
                {
                openDoorPushingE(lname);
                Debug.Log(lname);
                }
            
                
            }
            else
            {
                //Debug.Log("dentro del else");
            }*/
        }


            
            //openDoorPushingE(lname);

    }
    public void ActivateCanvas(bool inVision )
    {
        detectedCanvas.gameObject.SetActive(inVision);

    }

    public void openDoorPushingE ()
    {
        animatorDoor.SetBool("estaDentro", true); 
        //Debug.Log(animatorDoor.gameObject);
        //if (Keyboard.current.eKey.IsPressed())
        //{
           /** switch (tagname)
            {
                case "buttonDoorA":
                    Debug.Log("A");
                               
                    break;
                case "buttonDoorB":
                    Debug.Log("B");
                    animatorDoor.SetBool("estaDentroB", true);    
                    break;
                default:
                    Debug.Log("ninguno");
                    break;
                    
                   
            }**/ 
            
        //}
        //Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity );


    }


}

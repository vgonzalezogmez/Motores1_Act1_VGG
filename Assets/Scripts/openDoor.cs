using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class openDoor : MonoBehaviour
{

//[SerializeField] float radius = 1f;
[SerializeField] Canvas detectedCanvas;
public Animator animatorDoor;


    // Update is called once per frame
    void Update()
    {
        

    }
    public void ActivateCanvas(bool inVision )
    {
        detectedCanvas.gameObject.SetActive(inVision);

    }
//
    public void openDoorPushingE ()
    {
        animatorDoor.SetBool("estaDentro", true); 
        
    }


}

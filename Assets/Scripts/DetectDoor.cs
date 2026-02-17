using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectDoor : MonoBehaviour
{
    public LayerMask lm;
    openDoor open;

    // Update is called once per frame
    void Update()
    {
        CheckButton();//cheque si veo un buton
    }
    public void CheckButton()
    {
        if (open != null)
        {
            open.ActivateCanvas(false);
        }
        
        Vector3 dir = transform.position -transform.forward;
        dir.Normalize();
        RaycastHit[] raycastHit = Physics.SphereCastAll(transform.position, 0.5f, transform.forward,1f, lm);
        for(int i=0;i<raycastHit.Length;i++)
        {
            if(((1<< raycastHit[i].collider.gameObject.layer) & lm ) !=0) 
            {
                if(raycastHit[i].collider.gameObject.TryGetComponent<openDoor>(out  open)==true)
                {
                    open.ActivateCanvas(true);
                    if (Keyboard.current.eKey.isPressed)
                    {
                        open.openDoorPushingE();
                    }
                }
            }
        }

    }
}

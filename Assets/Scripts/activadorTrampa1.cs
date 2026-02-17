using System.Collections;
using UnityEngine;

public class activadorTrampa1 : MonoBehaviour
{

    [SerializeField] GameObject toActivate;
    [SerializeField] VidaPlayer vida;
    public Animator animatortrampa;
    private bool trampaactivada= false;
   

    public void OnTriggerEnter(Collider other)
    {
        if ( trampaactivada==false)
        {
            
            if (other.tag =="Player")
            {
                
                toActivate.SetActive(true);
                animatortrampa.SetBool("estaDentro", true); 

                Vector3 pushdirection = -other.transform.forward;
                
                MovimientoPersonaje movplayer=other.GetComponent<MovimientoPersonaje>();
                if (movplayer!=null)
                {
                movplayer.AddKnockback(pushdirection,1f,0.1f);    
                }

                trampaactivada=true;
                Collider trampa1 = GetComponent<Collider>();

                trampa1.isTrigger=false;
            }                
            
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

    

}

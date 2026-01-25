using UnityEngine;

public class activadorTrampa1 : MonoBehaviour
{

    [SerializeField] GameObject toActivate;
    [SerializeField] VidaPlayer vida;
    
    private bool trampaactivada= false;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("se activa la trampa y su estado es:" + trampaactivada);
        if ( trampaactivada==false)
        {
            
            if (other.tag =="Player")
            {
                Debug.Log("trampa detectada");
                toActivate.SetActive(true);
                vida.recibirDaño();

                Vector3 pushdirection = -other.transform.forward;
                
                MovimientoPersonaje movplayer=other.GetComponent<MovimientoPersonaje>();
                if (movplayer!=null)
                {
                movplayer.AddKnockback(pushdirection,1f,0.1f);    
                }

                trampaactivada=true;
                Collider trampa = GetComponent<Collider>();
                trampa.isTrigger=false;
                
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

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class lvl1attack : MonoBehaviour
   
{
    

    // Start is called before the first frame update
    void Start()
    {
    }

        

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Player")
            {


                Debug.Log("player got hit");

            }



        } 
    
}

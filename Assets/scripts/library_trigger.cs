using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class library_trigger : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    

    
    

   


    void Start()
    {
        
    }

    void Update()
    {
       
            
            
               
               
           
        
    }



  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("wheelchair", 0, 0f);
        }
    }
}

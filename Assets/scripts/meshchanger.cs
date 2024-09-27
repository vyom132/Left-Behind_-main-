using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshchanger : MonoBehaviour
{
    
    public GameObject[] nextpet;
   
    
    // Start is called before the first frame update
    void Start()
    {
        nextpet[0].SetActive(true);
        nextpet[1].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            nextpet[1].SetActive(true);
            nextpet[0].SetActive(false);
            
        }
    }
}

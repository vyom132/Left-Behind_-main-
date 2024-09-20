using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class objectinteractor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void OnTriggerStay(Collider other)
    {
       

        if (other.gameObject.tag == "Player")
        {


            Debug.Log("display ui");
                



        }


    }


}

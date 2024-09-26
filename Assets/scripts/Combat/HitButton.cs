using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    public GameObject Particle;
    public GameObject particle2;
    public GameObject parent;
    
    async void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "hammer")
        {  
            GameObject hitOne = Instantiate(Particle, parent.transform.position, Quaternion.identity);
            GameObject hitTwo = Instantiate(particle2, parent.transform.position, parent.transform.rotation);
        }
    }
}

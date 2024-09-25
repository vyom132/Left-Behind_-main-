using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HitButton : MonoBehaviour
{
    public GameObject Particle;
    public GameObject particle2;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    async void OnTriggerEnter(Collider collider)
    {


        if (collider.gameObject.tag == "hammer")
        {



            
            GameObject hit = Instantiate(Particle, parent.transform.position, Quaternion.identity);
            GameObject hit2 = Instantiate(particle2, parent.transform.position, parent.transform.rotation);


        }
    }
}

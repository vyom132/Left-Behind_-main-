using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class lvl2_attack : MonoBehaviour
{
    public Animator anim;
    public float timeinterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

        
        

    }
    async void OnTriggerStay(Collider other)
    {
        //timeinterval -= Time.deltaTime;
        //timeinterval = 3;

        if (other.gameObject.tag == "Player")
        {


            anim.SetBool("in_range", true);



        }
        

    }

    // Update is called once per frame







}

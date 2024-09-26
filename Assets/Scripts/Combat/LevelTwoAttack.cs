using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelTwoAttack : MonoBehaviour
{
    public Animator anim;
    public float timeinterval;
    public GameObject Particle;
    public GameObject parent;
    
    async void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.Play("lvl2_attack");
        }
        
    }

//     async void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag == "Player")
//         {
//             await Task.Delay(1200);
//             GameObject hit = Instantiate(Particle, parent.transform.position, Quaternion.identity);
//         }
//    }
}

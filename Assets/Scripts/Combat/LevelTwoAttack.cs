using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LevelTwoAttack : MonoBehaviour
{
    public Animator anim;
    public float timeinterval;

    async void OnTriggerStay(Collider other)
    {
        //timeinterval -= Time.deltaTime;
        //timeinterval = 3;

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("in_range", true);
        }
    }
}

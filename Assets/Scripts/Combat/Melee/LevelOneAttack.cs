using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class LevelOneAttack : MonoBehaviour
{

    public Health HealthBarChanging;
    public float damager;

    void Start()
    {
        HealthBarChanging = Health.instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthBarChanging.takingDmg = true;
            HealthBarChanging.damage = damager;
            //Debug.Log(gameObject.name);
            //Debug.Log("player got hit");
        }


    }
    void OnTriggeExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthBarChanging.takingDmg = false;
            //Debug.Log("player stopped got hit");
        }


    }
}

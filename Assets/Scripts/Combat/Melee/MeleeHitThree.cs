using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitThree : MonoBehaviour
{
    public EnemyHealth EnemyHealthBarChanging;
    public float Enemydamager;

    private bool targetHit;

    void Start()
    {
        EnemyHealthBarChanging = EnemyHealth.instance;
        targetHit = false;
    }

   async private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EnemyHealthBarChanging.EnemytakingDmg = true;
            EnemyHealthBarChanging.Enemydamage = Enemydamager;
            Debug.Log("enemny got it3rd");
        }
    }

    async private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EnemyHealthBarChanging.EnemytakingDmg = false;
            Debug.Log("enemny stopped got it3rd");
        }
    }
}

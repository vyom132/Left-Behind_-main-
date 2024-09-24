using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitOne : MonoBehaviour
{
    public EnemyHealth EnemyHealthBarChanging;
    public float Enemydamager;

    private bool targetHit;


    void Start()
    {
        EnemyHealthBarChanging = EnemyHealth.instance;
        targetHit = false;
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EnemyHealthBarChanging.EnemytakingDmg = true;
            EnemyHealthBarChanging.Enemydamage = Enemydamager;
            Debug.Log("wall got it");
        }


        async void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "enemy")
            {
                EnemyHealthBarChanging.EnemytakingDmg = false;
                Debug.Log("enemny stopped got it3rd");
            }
        }
    }
}

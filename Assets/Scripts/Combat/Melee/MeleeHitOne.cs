using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeHitOne : MonoBehaviour
{
    public float Enemydamager;

    private bool targetHit;
    private EnemyHealth EnemyHealthBarChanging;

    void Start()
    {
        EnemyHealthBarChanging = EnemyHealth.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            EnemyHealthBarChanging.EnemytakingDmg = true;
            EnemyHealthBarChanging.Enemydamage = Enemydamager;
            Debug.Log("wall got it");
        }
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

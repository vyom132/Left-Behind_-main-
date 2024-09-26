using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            PlayerHealthManager.instance.TakeDamage(damage);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnAttackingLevelOne : MonoBehaviour
{
    public GameObject attack;
    public float InstantiationTimer;
    public GameObject parent;

    async void Update()
    {
        InstantiationTimer -= Time.deltaTime;

        if (InstantiationTimer <= 0)
        {
            GameObject at =  Instantiate(attack, parent.transform.position, Quaternion.identity);
            InstantiationTimer = 2f;
            await Task.Delay(100);
            Destroy(at);
        }
    }
}

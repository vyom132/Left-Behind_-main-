using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class spawnattackinglv1 : MonoBehaviour
{
    public GameObject attack;
    public float InstantiationTimer;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

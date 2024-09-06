using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    
public class NavAI : MonoBehaviour
{

    public NavMeshAgent ai;
    public Transform player;
    Vector3 dest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dest = player.position;
        ai.destination = dest;
    }
}

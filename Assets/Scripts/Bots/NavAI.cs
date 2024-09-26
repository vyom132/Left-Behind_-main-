using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    
public class NavAI : MonoBehaviour
{
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = PlayerManager.playerObject.transform.position;
    }
}

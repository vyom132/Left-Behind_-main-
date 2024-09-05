using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject Cubics;

    //psuher
    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cubics.SetActive(false);
        }
    }
}

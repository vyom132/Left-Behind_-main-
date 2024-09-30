using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSManager : MonoBehaviour
{
    private enum limits
    {
        nolimit = 0,
        limit30 = 30,
        limit60 = 60,
        limit120 = 120,
        limit240 = 240,
    }

    [SerializeField]
    private limits limit;

    void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
}

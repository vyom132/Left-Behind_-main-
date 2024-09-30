using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    void Start()
    {
        InventoryManager.instance.ResetValues();
        AudioManager.instance.ResetVolumes();
    }
}

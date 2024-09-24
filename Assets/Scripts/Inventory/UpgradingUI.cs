using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradingUI : MonoBehaviour
{
    public static UpgradingUI instance; void Awake() { instance = this; }

    public void ToggleUpgradingUI(bool turnOn) {
        gameObject.SetActive(turnOn);
    }
}

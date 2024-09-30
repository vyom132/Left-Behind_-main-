using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = AudioManager.volumes["master"];
    }

    void Update()
    {
        AudioManager.volumes["master"] = volumeSlider.value;
    }
}

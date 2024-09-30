using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings instance; void Awake() { instance = this; }
    // Start is called before the first frame update
    public Slider VolumeSlider;
    public static float Volume;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Volume = VolumeSlider.value;
       // Debug.Log(Volume);
    }
}

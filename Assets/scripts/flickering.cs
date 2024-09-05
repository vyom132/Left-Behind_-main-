using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class flickering : MonoBehaviour
{
    public Light light;
    // Start is called before the first frame update
    async void Start()
    {
        light.intensity = 0;
        await Task.Delay(100);
        light.intensity = 3.14f;
        await Task.Delay(100);
        light.intensity = 0;
        await Task.Delay(200);
        light.intensity = 3.14f;
        await Task.Delay(300);
    }

    // Update is called once per frame
    async void FixedUpdate()
    {
        

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class meele : MonoBehaviour
{
    public GameObject attack1;
    public GameObject meelee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            Instantiate(attack1,meelee.transform.position, meelee.transform.rotation);
            await Task.Delay(10000);
            Destroy(attack1);
            
        }
    }
}

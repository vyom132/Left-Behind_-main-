using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class meele : MonoBehaviour
{
    public GameObject attack1;
    public GameObject meelee1;
    public GameObject attack2;
    public GameObject meelee2;
    public GameObject attack3;
    public GameObject meelee3;
    public Animator anim;

    private bool at1D;
    private bool at2D;
    private bool at3D;
    // Start is called before the first frame update
    void Start()
    {
        at1D= false;
        at2D= false;
        at3D= false;
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetMouseButtonDown(0) & at1D == false & at3D == false & at2D == false)
        {
            
            GameObject at1 = Instantiate(attack1, meelee1.transform.position, meelee1.transform.rotation);
            at1D= true;
            anim.SetBool("at1", true);
            await Task.Delay(1500);
            
            Destroy(at1);
            at1D = false;
            

            

        }
        if (at1D & Input.GetMouseButtonDown(0) & at2D == false) 
        {
            GameObject at2 = Instantiate(attack2, meelee2.transform.position, meelee2.transform.rotation);
            at2D = true;
            anim.SetBool("at2", true);
            await Task.Delay(1500);
            
            Destroy(at2);
            at2D = false;
        }
        if (at2D & at1D & Input.GetMouseButtonDown(0))
        {
            GameObject at3 = Instantiate(attack3, meelee3.transform.position, meelee3.transform.rotation);
            at3D = true;
            anim.SetBool("at3", true);
            await Task.Delay(500);

            Destroy(at3);
            at3D = false;
        }
       
        if (at1D!)
        {

            anim.SetBool("at1", false);
        }


        if (at2D!)
        {

            anim.SetBool("at2", false);
        }
        if (at3D!)
        {

            anim.SetBool("at3", false);
        }



    }
}

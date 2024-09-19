using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    

    private Dialouge dialouge;

    public GameObject Interact;

    public Animator animator;
    float interactRange = 2f;

    bool isDialougeRunning = false;
    bool rand = false;

    // Start is called before the first frame update
    void Start()
    {
        dialouge = Dialouge.instance;
        Interact.SetActive(false);
    }

    // Update is called once per frame  
    void Update()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position,  interactRange);

        if (Input.GetKeyDown(KeyCode.E)) {            
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out BotInteract botInteract) && animator.GetBool("isOpen") == false) {
                    dialouge.canType = true;
                    StartDialouge();

                }
            }
        }
        
        foreach (Collider collider in colliderArray) {
            // while (collider.TryGetComponent(out BotInteract botInteract)) {
            //     Interact.SetActive(true);
            // } 
        } 

        // foreach (Collider collider1 in colliderArray) {
        //     if (collider1.TryGetComponent(out BotInteract botInteract)) {
        //         Interact.SetActive(true);
        //         Debug.Log("show");
        //     } 
            // else {
            //     Interact.SetActive(false);
            // }
            // else if (!collider1.TryGetComponent(out BotInteract botInteract1)) {
            //     Interact.SetActive(false);
            //     Debug.Log("dont show");
            // }
        // }

        if (dialouge.isDialougeEnd == true) {
            animator.SetBool("isOpen", false);  
            dialouge.isDialougeEnd =  false;
        }
 
    }

    void StartDialouge() {
        animator.SetBool("isOpen",  true);
        dialouge.isDialougeEnd = false;


        dialouge.StartTyping();
        

        // set it to false after ur done ra niggesh 
    }


}

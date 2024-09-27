using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // public GameObject Interact;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float interactRange = 2f;

    private bool isDialougeRunning = false;
    private bool rand = false;
    private Dialogue dialouge;

    void Start()
    {
        dialouge = Dialogue.instance;
        // Interact.SetActive(false);
    }

    void Update()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position,  interactRange);

        if (Input.GetKeyDown(KeyCode.R)) {            
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out BotInteract botInteract) && animator.GetBool("isOpen") == false) {
                    dialouge.canType = true;
                    StartDialouge();
                }
            }
        }
        
        if (dialouge.isDialougeEnd == true) {
            animator.SetBool("isOpen", false);  
            dialouge.isDialougeEnd =  false;
        }
    }

    void StartDialouge() {
        animator.SetBool("isOpen",  true);
        dialouge.isDialougeEnd = false;
        dialouge.StartTyping();
    }
}

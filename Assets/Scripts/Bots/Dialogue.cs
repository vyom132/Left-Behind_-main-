using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance; void Awake() { instance = this; }
    
    public bool isDialougeEnd; 
    public bool canType;

    [SerializeField]
    private Text textComp;
    [SerializeField]
    private DialogueTexts dialogueTexts;
    [SerializeField]
    private float textSpeed;

    private int index;
    private List<string> lines = new List<string>();

    void Start()
    {
        textComp.text = string.Empty;
        canType = false;
        lines.Clear();

        UpdateDialogue(dialogueTexts.GetDialogues());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canType == true) {
            if (textComp.text == lines[index]) {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    public void UpdateDialogue(List<string> dialogues) {
        lines.Clear();
        foreach (string dialogue in dialogues) {
            lines.Add(dialogue);
        }
    }

    public void MoveToNextLine() {
        Debug.Log("hi");
        if (textComp.text == lines[index]) {
            NextLine();
        } else
        {
            StopAllCoroutines();
            textComp.text = lines[index];
        }
    }

    public void StartTyping() {
        UpdateDialogue(dialogueTexts.GetDialogues());
        dialogueTexts.exhausted = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) 
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if (index < lines.Count - 1) {
            index++;    
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        } else
        {
            isDialougeEnd = true;
            Debug.Log("saasd");
            canType = false;
            textComp.text = string.Empty;
        }
    }
}
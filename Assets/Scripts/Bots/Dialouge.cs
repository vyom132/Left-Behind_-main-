using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Dialouge : MonoBehaviour
{
    public static Dialouge instance; void Awake() { instance = this; }
    
    public bool isDialougeEnd; 

    public Text textComp;
    public List<string> lines = new List<string>();
    public float textSpeed;

    public bool canType;

    private int index;

    void Start()
    {
        textComp.text = "";
        lines.Clear();
        lines.Add("Add you own Dialouge1");
        lines.Add("Add you own Dialouge2");
        lines.Add("Add you own Dialouge3");



        canType = false;
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
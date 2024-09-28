using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PlayerManager script;
    public GameObject script2;
    public List<GameObject> objects;
    [SerializeField]
    
    public GameObject pausePanel;
    private bool pauseMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        pauseMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuOpen)
        {
            Debug.Log("Opened");
            pausePanel.SetActive(true);
            pauseMenuOpen = true;
            script.enabled= false;
            script2.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            foreach (var thing in objects){
                thing.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOpen)
        {
            script2.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("closed");
            pausePanel.SetActive(false);
            pauseMenuOpen = false;
            script.enabled = true;
            foreach (var thing in objects)
            {
                thing.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pauseMenuOpen = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOpen)
        {
            Debug.Log("closed");
            pausePanel.SetActive(false);
            pauseMenuOpen = false;
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pauseMenuOpen = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject script2;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private GameObject pausePanel;

    private bool pauseMenuOpen;
    private PlayerManager playerManager;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseMenuOpen = false;
        playerManager = PlayerManager.instance.gameObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = !pauseMenuOpen;

            pausePanel.SetActive(!pauseMenuOpen);
            pauseMenuOpen = !pauseMenuOpen;
            playerManager.enabled = pauseMenuOpen;
            script2.SetActive(pauseMenuOpen);

            foreach (var thing in enemies) {
                thing.SetActive(pauseMenuOpen);
            }

            if (pauseMenuOpen) {
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log("Closed pause menu");
            } else
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("Opened pause menu");
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pauseMenuOpen = false;
    }
}

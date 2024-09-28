using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int SceneToGo;
    public bool GameOver;
    [SerializeField] private int Gameer;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneChange();
        }

    }

    void SceneChange()
    {
        if(GameOver) { 
        SceneManager.LoadScene(Gameer);
            return;
        
        }
        SceneManager.LoadScene(SceneToGo);
    }
}

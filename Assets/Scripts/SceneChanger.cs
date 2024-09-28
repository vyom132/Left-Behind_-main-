using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int SceneToGo;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneChange();
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene(SceneToGo);
    }
}

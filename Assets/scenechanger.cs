using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    [SerializeField] private string SceneToGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
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

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // public Text healthText;
    public Image healthBar;

    float lerpSpeed;

    float health;
    float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        if (health > 0) {
            
            health -= 10 * Time.fixedDeltaTime;
        }

        // healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/100, lerpSpeed);
        healthBar.fillAmount = health/100;
    }
}

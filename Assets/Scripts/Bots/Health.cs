using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // public Text healthText;
    public Image healthBar;

    public Text playerkahealth;

    public Text botkaenergyhealthbar;



    public Image PlayerHealth;

    public float damage = 30;
    public float healthnipenchurakojja = 30;

    float lerpSpeed = 5f;

    float health;

    float healthPlayer;

    int botHealth;

    float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthPlayer = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (health > 0)
        {
            health -= 10 * Time.deltaTime;
            botHealth -= 10;
        }

        if (Input.GetKeyDown(KeyCode.V) && healthPlayer > 0)
        {
            if (healthPlayer <= damage)
            {
                healthPlayer = 0;
            }
            if (healthPlayer > damage)
            {
                healthPlayer -= damage;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && healthPlayer < 100 && (100 - healthPlayer) <= healthnipenchurakojja)
        {
            healthPlayer = 100;
        }

        if (Input.GetKeyDown(KeyCode.K) && healthPlayer < 100 && (100 - healthPlayer) > healthnipenchurakojja)
        {
            healthPlayer += healthnipenchurakojja;
        }

        // healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/100, lerpSpeed);
        // healthBar.fillAmount = health/100;

        if (health < 100 && Input.GetKeyDown(KeyCode.H))
        {
            health += 30;
            botHealth += 10;
            Debug.Log("Yo");
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / 100, lerpSpeed * Time.deltaTime);
        }

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / 100, lerpSpeed * Time.deltaTime);
        // healthBar.fillAmount = health/100;
        PlayerHealth.fillAmount = Mathf.Lerp(PlayerHealth.fillAmount, healthPlayer / 100, lerpSpeed * Time.deltaTime);



        playerkahealth.text = healthPlayer.ToString();
        // botkaenergyhealthbar.text = botHealth.ToString();

    }
}
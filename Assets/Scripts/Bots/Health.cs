using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public static Health instance; void Awake() { instance = this; }

    public float damage;

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private TMP_Text playerkahealth;
    [SerializeField]
    private Image PlayerHealth;
    [SerializeField]
    private float healthnipenchurakojja = 30;
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float lerpSpeed = 5f;

    private float health;
    private float healthPlayer;
    private int botHealth;
    public bool takingDmg = false;

    void Start()
    {
        health = maxHealth;
        healthPlayer = maxHealth;
    }

    void Update()
    {
        if (health > 0) {
            health -= 10 * Time.deltaTime;
            botHealth -= 10;
        }

        if (takingDmg && healthPlayer > 0) {
            if (healthPlayer <= damage) {
                healthPlayer = 0;
                takingDmg = false;
            }
            else if (healthPlayer > damage) {
                healthPlayer -= damage;
                takingDmg = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && healthPlayer < 100 && (100 - healthPlayer) <= healthnipenchurakojja) {
            healthPlayer = 100;
        }

        if (Input.GetKeyDown(KeyCode.K) && healthPlayer < 100 && (100 - healthPlayer) > healthnipenchurakojja) {
            healthPlayer += healthnipenchurakojja;
        }

        // healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/100, lerpSpeed);
        // healthBar.fillAmount = health/100;

        if (health < 100 && Input.GetKeyDown(KeyCode.H)) {
            health += 30;
            botHealth += 10;
            Debug.Log("Yo");
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/100, lerpSpeed * Time.deltaTime);   
        }

        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health/100, lerpSpeed * Time.deltaTime);
        // healthBar.fillAmount = health/100;
        PlayerHealth.fillAmount = Mathf.Lerp(PlayerHealth.fillAmount, healthPlayer/100, lerpSpeed * Time.deltaTime);

        playerkahealth.text = healthPlayer.ToString();
        // botkaenergyhealthbar.text = botHealth.ToString();
    }
}

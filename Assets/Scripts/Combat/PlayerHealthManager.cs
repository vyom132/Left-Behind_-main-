using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance; void Awake() { instance = this; }

    public static float energy;
    public static float health;

    [SerializeField]
    private Image energyBar;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
    private float healAmount = 30f;
    [SerializeField]
    private float energyDecreaseRate = 2.5f;
    [SerializeField]
    private float energyIncreaseProportion = 0.1f;
    [SerializeField]
    private float lerpSpeed = 2f;

    void Start()
    {
        energy = maxHealth;
        health = maxHealth;
    }

    void Update()
    {
        if (energy <= 0) {
            Debug.Log("Game over(energy became 0)");
        } else
        {
            energy -= energyDecreaseRate * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        ConsumeEnergy();

        energyBar.fillAmount = Mathf.MoveTowards(energyBar.fillAmount, energy/maxHealth, lerpSpeed * Time.deltaTime);
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, health/maxHealth, lerpSpeed * Time.deltaTime);
        healthText.text = health.ToString();
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            health = 0;
            Debug.Log("Game over(health became 0)");
        } else if(health > maxHealth)
        {
            health = maxHealth;
        }

        if (damage >= 0)
        MeleeAttackManager.instance.inCombat = true;
    }

    public void RegenerateEnergy(float damage) {
        energy += damage * energyIncreaseProportion;
        if(energy > maxHealth)
        {
            energy = maxHealth;
        }
    }

    public void ConsumeEnergy() {
        if (energy < healAmount) {
            Debug.Log("Can't consume energy");
            return;
        }
        energy -= healAmount;
        TakeDamage(-healAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance; void Awake() { instance = this; }

    public Image EnemyHealthBar;
    public float Enemydamage;
    float lerpSpeed = 5f;
    float Enemyhealth;
    public float maxEnemyHealth;
    public bool EnemytakingDmg = false;

    // Start is called before the first frame update
    void Start()
    {
        Enemyhealth = maxEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemytakingDmg && Enemyhealth > 0)
        {
            Enemyhealth -= Enemydamage;
            EnemytakingDmg = false;
        }

        EnemyHealthBar.fillAmount = Mathf.Lerp(EnemyHealthBar.fillAmount, Enemyhealth / maxEnemyHealth, lerpSpeed * Time.deltaTime);
    }
}

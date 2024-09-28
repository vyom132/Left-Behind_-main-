using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject soundeffect;

    [SerializeField]
    private EnemyLoot loot;
    public bool inDome;

    [SerializeField]
    private GameObject objectToDestroy;
    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float lerpSpeed = 2f;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private GameObject parent;

    public float health;
    [SerializeField] private int SceneToGo;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, health/maxHealth, lerpSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        Debug.Log("Enemy got hit with damage " + damage);

        if (health <= 0) {
            health = 0;
            Instantiate(particle, parent.transform.position, Quaternion.identity);

            for (int i = 0; i < loot.items.Count; i++) {
                InventoryManager.instance.Increase(loot.items[i], loot.counts[i]);
            }

            Instantiate(soundeffect, transform.position, Quaternion.identity);
            
            if (inDome)
            Dialogue.instance.domeEnemiesKilled += 1;
            Debug.Log("real");
            Destroy(gameObject);
            
        }
        
    }
}

using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public int experienceToGive;

    private PlayerStats _thePlayerStats;

    // Use this for initialization
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        _thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
            _thePlayerStats.AddExperience(experienceToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    public void HealEnemy(int amountToHeal)
    {
        enemyCurrentHealth += amountToHeal;
    }
}

using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int _currentDamage;

    public GameObject damageNumber;

    private PlayerStats _thePlayerStats;
    void Start()
    {
        _thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            _currentDamage = damageToGive - _thePlayerStats.currentDefence;

            if (_currentDamage <= 0)
            {
                _currentDamage = 1;
            }

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(_currentDamage);
            Debug.Log("Otrzymane obrazenia " + _currentDamage + " od " + gameObject.name);

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = _currentDamage;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class EnemyTakeDamage : MonoBehaviour, ITakeDamage
    {
        private EnemyHealth _enemyHealth;
        void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }
        public void TakeDamage(float damageAmount)
        {
            _enemyHealth.SetHealth(-damageAmount);
            Debug.Log("Damage : " + damageAmount.ToString());
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerAttack"))
            {
                TakeDamage(PlayerAttackController.Instance.TakeDamage());
                
            }
        }

    }
}

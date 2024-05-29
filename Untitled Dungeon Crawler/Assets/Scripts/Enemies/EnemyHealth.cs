using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UntitledDungeonCrawler
{
    public class EnemyHealth : MonoBehaviour
    {
        public Slider HealthSlider;
        private float _maxHealth;
        public float CurrentHealth;
        public bool IsKillable = false;

        void Start()
        {
            CurrentHealth = _maxHealth;
        }
        public void SetHealth(float amount)
        {
            CurrentHealth += amount;
        }
        public float GetHealth()
        {
            return CurrentHealth;
        }
        public void SetMaxHealth(float amount)
        {
            _maxHealth += amount;
        }
        public float GetMaxHealth()
        {
            return _maxHealth;
        }
        void Update()
        {
            HealthSlider.value = CurrentHealth / _maxHealth;
            if (CurrentHealth<=0)
            {
                CurrentHealth = .3f;
                IsKillable = true;
            }
        }
    }
}

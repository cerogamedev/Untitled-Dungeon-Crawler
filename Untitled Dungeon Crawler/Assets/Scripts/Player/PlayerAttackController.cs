using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class PlayerAttackController : MonoSingleton<PlayerAttackController>
    {
        public bool IsAttacking = false;
        public bool CanFill = true;
        public float WaitingTime;
        private AttackSliderManager sliderManager;
        void Awake()
        {
            sliderManager = AttackSliderManager.Instance;
        }

        void Update()
        {
            if (IsAttacking && InputHandler.Instance.IsAttackButtonPressed && CanFill)
            {
                sliderManager.FillIt = true;
            }
            if ((IsAttacking && !InputHandler.Instance.IsAttackButtonPressed) || sliderManager.AttackSlider.value == 1)
            {
                CanFill = false;
                sliderManager.FillIt = false;
                StartCoroutine(StopAttack());
            }
        }
        public void StartAttack()
        {
            sliderManager.SetItActive();
            IsAttacking = true;
            CanFill = true;
            PlayerController.Instance.IsCanPlayerMove = false;
            PlayerController.Instance.rb.velocity = Vector2.zero;
        }
        public IEnumerator StopAttack()
        {
            if (sliderManager.AttackSlider.value > 0.8 && sliderManager.AttackSlider.value<=0.9) {sliderManager.Filler.color = Color.green;}
            if (sliderManager.AttackSlider.value > 0.9 && sliderManager.AttackSlider.value<0.95) {sliderManager.Filler.color = Color.cyan;}

            yield return new WaitForSeconds(WaitingTime);
            sliderManager.SetItClose();
            IsAttacking = false;
            CanFill = true;
            PlayerController.Instance.IsCanPlayerMove = true;
        }
    }
}

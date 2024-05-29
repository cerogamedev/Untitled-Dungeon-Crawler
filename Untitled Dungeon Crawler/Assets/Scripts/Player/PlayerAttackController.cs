using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class PlayerAttackController : MonoSingleton<PlayerAttackController>
    {
        public bool IsAttacking = false;
        public bool CanFill = true;
        public float WaitingTime;
        private AttackSliderManager sliderManager;
        public GameObject AttackObject, ShadowObject;
        private CircleCollider2D attackObjectCollider;
        private float _attackIndex;
        public float Attack;
        void Awake()
        {
            sliderManager = AttackSliderManager.Instance;
            attackObjectCollider = AttackObject.GetComponent<CircleCollider2D>();
        }

        void Update()
        {
            //attackObjectCollider.radius = sliderManager.AttackSlider.value + 0.5f;
            if (IsAttacking && InputHandler.Instance.IsAttackButtonPressed && CanFill)
            {
                ShadowObject.SetActive(true);
                sliderManager.FillIt = true;
                if (sliderManager.AttackSlider.value>0.3f)
                {
                    sliderManager.SetItActive();
                    PlayerController.Instance.IsCanPlayerMove = false;
                    PlayerController.Instance.rb.velocity = UnityEngine.Vector2.zero;

                    ShadowObject.transform.localScale = new (2*math.PI*sliderManager.AttackSlider.value,2*math.PI*sliderManager.AttackSlider.value,1.0f);
                    attackObjectCollider.radius = sliderManager.AttackSlider.value;
                }

            }
            if ((IsAttacking && CanFill && !InputHandler.Instance.IsAttackButtonPressed) || (sliderManager.AttackSlider.value == 1 && InputHandler.Instance.IsAttackButtonPressed))
            {
                CanFill = false;
                sliderManager.FillIt = false;
                StartCoroutine(StopAttack());
            }
        }
        public void StartAttack()
        {
            sliderManager.SetItClose();
            IsAttacking = true;
            CanFill = true;
            PlayerController.Instance.rb.velocity = UnityEngine.Vector2.zero;
        }
        public IEnumerator StopAttack()
        {
            //Collider true
            // Turn into function for attack value and successful attack
        
            if (sliderManager.AttackSlider.value > 0.8f && sliderManager.AttackSlider.value<=0.92f) {sliderManager.Filler.color = Color.green;}
            if (sliderManager.AttackSlider.value > 0.92f && sliderManager.AttackSlider.value<0.99f) {sliderManager.Filler.color = Color.cyan;}
            TakeDamage(TakeDamageAmounth());
            float waitFor = WaitingTime;
            //Animation speed = waitFor 
            //faster animation speed when value < 0.3f
            if (sliderManager.AttackSlider.value<0.3f) {waitFor = WaitingTime/10;}
            else {waitFor = WaitingTime;}
            yield return new WaitForSeconds(waitFor);
            sliderManager.SetItClose();
            IsAttacking = false;
            CanFill = true;
            PlayerController.Instance.IsCanPlayerMove = true;
            ShadowObject.transform.localScale = new (1.0f,1.0f,1.0f);
            attackObjectCollider.radius = 0.5f;
        }
        public void TakeDamage(float damage)
        {
            UnityEngine.Vector2 pos = attackObjectCollider.transform.position;
            float radius = attackObjectCollider.radius;
            Collider2D [] colliders = Physics2D.OverlapCircleAll(pos, radius);

            foreach (Collider2D collider in colliders)
            {
                ITakeDamage damagable = collider.GetComponent<ITakeDamage>();
                if (damagable!=null) {damagable.TakeDamage(damage);}
            }
        }
        public float TakeDamageAmounth()
        {
            if (sliderManager.AttackSlider.value<0.3f){_attackIndex = Attack;}
            if (sliderManager.AttackSlider.value > 0.7f && sliderManager.AttackSlider.value<=0.92f) {_attackIndex = Attack + (sliderManager.AttackSlider.value*2);}
            if (sliderManager.AttackSlider.value > 0.92f && sliderManager.AttackSlider.value<0.99f) {_attackIndex = Attack + (sliderManager.AttackSlider.value*4);}
            if (sliderManager.AttackSlider.value == 1) { _attackIndex = 0;}
            //else {_attackIndex = 0;}
            return _attackIndex;
        }
    }
}

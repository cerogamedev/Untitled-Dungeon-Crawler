using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UntitledDungeonCrawler
{
    public class AttackSliderManager : MonoSingleton<AttackSliderManager>
    {
        [Header("Objects")]
        public Slider AttackSlider;
        public Image Filler;
        public GameObject MainCanva;
        [Header("Var")]
        public float FillSpeed;
        public bool FillIt = false;
        void Awake()
        {
            MainCanva.SetActive(false);
            AttackSlider.value = 0;
        }
        void Update()
        {
            if (FillIt) {AttackSlider.value += FillSpeed;}
        }
        public void SetItActive()
        {
            MainCanva.SetActive(true);
            AttackSlider.value = 0;
            Filler.color = Color.red;
        }
        public void SetItClose()
        {
            MainCanva.SetActive(false);
            AttackSlider.value = 0;
        }

    }
}

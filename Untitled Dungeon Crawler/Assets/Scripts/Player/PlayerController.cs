using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Properties")]
        public static ControlTypesSO _control;
        private float _force;
        private float _lastForce;
        private Rigidbody2D rb;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _force = _control.Force;
            _lastForce = _control.LastForce;
        }
        // Update is called once per frame
        void Update()
        {
            //USE THE FORCE FOR MOVEMENT!!!
        }
    }
}

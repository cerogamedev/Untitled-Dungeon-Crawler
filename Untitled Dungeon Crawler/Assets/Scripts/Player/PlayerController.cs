using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class PlayerController : MonoSingleton<PlayerController>
    {
        [Header("Player Properties")]
        public ControlTypesSO _control;
        private float _force;
        public Rigidbody2D rb;
        private InputHandler inputHandler;
        public bool IsCanPlayerMove = true;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _force = _control.Force;
            inputHandler = InputHandler.Instance;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsCanPlayerMove)
            {
                Vector2 inputVector = inputHandler.GetMovementVector();
                rb.velocity = inputVector * _force;
            }
        }
    }
}

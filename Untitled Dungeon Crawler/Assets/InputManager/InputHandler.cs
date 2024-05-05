using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace UntitledDungeonCrawler
{
    public class InputHandler : MonoSingleton<InputHandler>
    {
        private PlayerInput playerInput;
        public bool IsAttackButtonPressed;
        void Awake()
        {
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
        }
        public void Update()
        {
            IsAttackButtonPressed = playerInput.Player.Attack.IsPressed();
        }
        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }
    }
}

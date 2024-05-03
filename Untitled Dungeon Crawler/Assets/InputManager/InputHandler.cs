using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace UntitledDungeonCrawler
{
    public class InputHandler : MonoBehaviour
    {
        public PlayerInput playerInput;
        void Awake()
        {
            playerInput = new PlayerInput();
            playerInput.Player.Enable();
            
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private IState currentState;

        void Start()
        {
            ChangeState(new IdleState());
        }

        void Update()
        {
            currentState.UpdateState(this);
        }

        public void ChangeState(IState newState)
        {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}

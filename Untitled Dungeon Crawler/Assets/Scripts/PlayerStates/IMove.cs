using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class IMove :  IState
    {
        public void EnterState(PlayerStateMachine player)
        {
            Debug.Log("Entering Move State!!!");
        }

        public void ExitState(PlayerStateMachine player)
        {
            Debug.Log("Exiting Move State!!!");

        }

        public void UpdateState(PlayerStateMachine player)
        {
            if (InputHandler.Instance.GetMovementVector() == Vector2.zero) {player.ChangeState(new IdleState());}
        }

    }
}

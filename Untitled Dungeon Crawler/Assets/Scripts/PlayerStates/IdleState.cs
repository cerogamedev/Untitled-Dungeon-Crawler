using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class IdleState :  IState
    {
        public void EnterState(PlayerStateMachine player)
        {
            Debug.Log("Entering Idle State!!!");
        }

        public void ExitState(PlayerStateMachine player)
        {
            Debug.Log("Exiting Idle State!!!");
        }

        public void UpdateState(PlayerStateMachine player)
        {
            if (InputHandler.Instance.GetMovementVector() != Vector2.zero) {player.ChangeState(new IMove());}
            if (InputHandler.Instance.IsAttackButtonPressed && !PlayerAttackController.Instance.IsAttacking){player.ChangeState(new IAttack());}
        }

    }
}

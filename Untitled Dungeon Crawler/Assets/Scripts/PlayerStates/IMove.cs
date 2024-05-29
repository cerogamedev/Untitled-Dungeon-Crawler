using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class IMove :  IState
    {
        public void EnterState(PlayerStateMachine player)
        {
        }

        public void ExitState(PlayerStateMachine player)
        {

        }

        public void UpdateState(PlayerStateMachine player)
        {
            if (InputHandler.Instance.GetMovementVector() == Vector2.zero) {player.ChangeState(new IdleState());}
            if (InputHandler.Instance.IsAttackButtonPressed && !PlayerAttackController.Instance.IsAttacking){player.ChangeState(new IAttack());}

        }

    }
}

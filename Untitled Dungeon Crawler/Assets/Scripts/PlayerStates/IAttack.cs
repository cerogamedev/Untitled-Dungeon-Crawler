using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UntitledDungeonCrawler
{
    public class IAttack : IState
    {
        public void EnterState(PlayerStateMachine player)
        {
            PlayerAttackController.Instance.StartAttack();
        }

        public void ExitState(PlayerStateMachine player)
        {
        }

        public void UpdateState(PlayerStateMachine player)
        {
            if (PlayerAttackController.Instance.CanFill && !PlayerAttackController.Instance.IsAttacking)
            {
                player.ChangeState(new IdleState());
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public interface IState
    {
        void EnterState(PlayerStateMachine player);
        void UpdateState(PlayerStateMachine player);
        void ExitState(PlayerStateMachine player);

    }
}

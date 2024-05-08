using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public abstract class IEnemyState
    {
        public abstract void EnterState(EnemySM enemyControl);
        public abstract void ExitState(EnemySM enemyControl);
        public abstract void UpdateState(EnemySM enemyControl);

    }
}

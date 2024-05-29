using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class IEnemyFollow : IEnemyState
    {
        public Transform player;
        public override void EnterState(EnemySM enemyControl)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            enemyControl.aiPath.maxSpeed = enemyControl.FollowSpeed;
        }

        public override void ExitState(EnemySM enemyControl)
        {
        }

        public override void UpdateState(EnemySM enemyControl)
        {
            enemyControl.aiPath.maxSpeed = enemyControl.FollowSpeed;
            enemyControl.aiPath.destination = player.position;

        }


    }
}

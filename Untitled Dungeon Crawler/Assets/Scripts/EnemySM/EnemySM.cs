using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class EnemySM : MonoBehaviour
    {
        public IEnemyState currentState;

        public Transform LeftOrder, RightOrder;
        public float PatrolSpeed;
        public float maxWaitDuration;
        void Start()
        {
            ChangeState(new IEnemyPatrol());
        }
        void Update()
        {
            currentState.UpdateState(this);
        }
        public void ChangeState(IEnemyState newState)
        {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}

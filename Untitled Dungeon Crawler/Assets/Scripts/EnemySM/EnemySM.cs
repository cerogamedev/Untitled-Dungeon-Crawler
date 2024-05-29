using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

namespace UntitledDungeonCrawler
{
    public class EnemySM : MonoBehaviour
    {
        public AIPath aiPath;
        public Transform[] PatrolPoints;

        public EnemyType _enemyType;
        public EnemyTypesSO enemyType;
        public IEnemyState currentState;
        public float PatrolSpeed;
        public float maxWaitDuration;
        public float FollowSpeed;
        public float AttackSpeed;
        public float BeforeAttackDuration;
        public GameObject GhostCursedItem;
        public float DemonHealthIncreaseIndex;
        public float HealthIncreaseIndex;
        public int RoomNumber;

        private EnemyHealth enemyHealth;

        void Awake()
        {
            _enemyType = enemyType.enemyType;
            enemyHealth = GetComponent<EnemyHealth>();
            aiPath = GetComponent<AIPath>();
            PatrolSpeed = enemyType.PatrolSpeed;
            maxWaitDuration = enemyType.PatrolWaitDurationMax;
            GetComponent<EnemyHealth>().SetMaxHealth(enemyType.MaxHealth);
            FollowSpeed = enemyType.FollowSpeed;
            AttackSpeed = enemyType.AttackSpeed;
            BeforeAttackDuration = enemyType.BeforeAttackDuration;
            GhostCursedItem = enemyType.GhostCursedItem;
            DemonHealthIncreaseIndex = enemyType.DemonHealthIncreaseIndex;
            HealthIncreaseIndex = enemyType.HealthIncreaseIndex;
            RoomNumber = enemyType.RoomNumber;
        }
        void Start()
        {
            ChangeState(new IEnemyPatrol());
        }
        void Update()
        {
            currentState.UpdateState(this);
            PatrolSpeed = enemyType.PatrolSpeed * (enemyHealth.CurrentHealth / enemyHealth.GetMaxHealth());
            FollowSpeed = enemyType.FollowSpeed * (enemyHealth.CurrentHealth / enemyHealth.GetMaxHealth());

        }
        public void ChangeState(IEnemyState newState)
        {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}

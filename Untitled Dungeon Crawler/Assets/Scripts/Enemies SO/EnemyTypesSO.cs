using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public enum EnemyType
    {
        Vampire,
        Ghoul,
        Ghost,
        Zombie,
        Skeleton,
        Demon,
        Werewolf
    }
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Assets/Scripts/Enemies SO")]
    public class EnemyTypesSO : ScriptableObject
    {
        public EnemyType enemyType;
        public float MaxHealth;
        public float PatrolSpeed;
        public float PatrolWaitDurationMax;
        public float FollowSpeed;
        public float AttackSpeed;
        public float BeforeAttackDuration;
        public GameObject GhostCursedItem;
        public float DemonHealthIncreaseIndex;
        public float HealthIncreaseIndex;
        public int RoomNumber;
    }
}

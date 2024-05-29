using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class EnemyObserver : MonoBehaviour
    {
        private EnemySM enemySM;
        public List<EnemySM> allEnemies = new List<EnemySM>();
        void Awake()
        {
            enemySM = GetComponentInParent<EnemySM>();
            GameObject[] allEnemiesObject = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i<allEnemiesObject.Length;i++)
            {
                EnemySM enemy = allEnemiesObject[i].GetComponent<EnemySM>();
                allEnemies.Add(enemy);
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                enemySM.ChangeState(new IEnemyFollow());
                foreach(EnemySM enemy in allEnemies)
                {
                    if (enemy.RoomNumber == enemySM.RoomNumber)
                    {
                        enemy.ChangeState(new IEnemyFollow());
                    }
                }
            }
        }
    }

}

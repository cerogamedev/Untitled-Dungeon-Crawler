using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class IEnemyPatrol : IEnemyState
    {
        Vector2 point;
        bool isWaiting = false; 
        Coroutine waitCoroutine; 

        public override void EnterState(EnemySM enemyControl)
        {
            point = GetPoint(enemyControl);
        }

        public override void ExitState(EnemySM enemyControl)
        {
            if (waitCoroutine != null)
            {
                enemyControl.StopCoroutine(waitCoroutine);
            }
        }

        public override void UpdateState(EnemySM enemyControl)
        {
            enemyControl.aiPath.destination = point;
            enemyControl.aiPath.maxSpeed = enemyControl.PatrolSpeed;
            if (Vector2.Distance(enemyControl.transform.position, point) < 0.3f && !isWaiting)
            {
                waitCoroutine = enemyControl.StartCoroutine(WaitForDelay(enemyControl));
            }
        }

        public Vector2 GetPoint(EnemySM enemyControl)
        {
            int randomPoint = Random.Range(0,enemyControl.PatrolPoints.Length);
            Vector2 goPoint = enemyControl.PatrolPoints[randomPoint].transform.position;
            return goPoint;
        }

        IEnumerator WaitForDelay(EnemySM enemyControl)
        {
            isWaiting = true;
            float waitingRange = Random.Range(0,enemyControl.maxWaitDuration);
            yield return new WaitForSeconds(waitingRange); 
            point = GetPoint(enemyControl);
            isWaiting = false; 
        }
    }
}

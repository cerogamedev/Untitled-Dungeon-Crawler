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
            point = GetPoint(enemyControl.LeftOrder, enemyControl.RightOrder);
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
            enemyControl.transform.position = Vector2.MoveTowards(enemyControl.transform.position, point, enemyControl.PatrolSpeed / 100);
            if (Vector2.Distance(enemyControl.transform.position, point) < 0.3f && !isWaiting)
            {
                waitCoroutine = enemyControl.StartCoroutine(WaitForDelay(enemyControl));
            }
        }

        public Vector2 GetPoint(Transform leftOrder, Transform rightOrder)
        {
            float left = Random.Range(leftOrder.position.x, rightOrder.position.x);
            float right = Random.Range(rightOrder.position.y, leftOrder.position.y);
            Vector2 goPoint = new Vector2(left, right);
            return goPoint;
        }

        IEnumerator WaitForDelay(EnemySM enemyControl)
        {
            isWaiting = true;
            float waitingRange = Random.Range(0,enemyControl.maxWaitDuration);
            yield return new WaitForSeconds(waitingRange); 
            point = GetPoint(enemyControl.LeftOrder, enemyControl.RightOrder);
            isWaiting = false; 
        }
    }
}

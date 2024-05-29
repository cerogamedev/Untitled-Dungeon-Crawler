using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public class RotateMousePos : MonoSingleton<RotateMousePos>, IRotate
    {
        public bool IsRotate = true;
        public float RotationSpeed;
        public void IRotateTowards(Vector3 targetPosition, float rotationSpeed)
        {
                Vector2 direction = targetPosition - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation ,rotationSpeed*Time.deltaTime);
        }
        void Update()
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; 

            if (IsRotate) {IRotateTowards(targetPosition, RotationSpeed);}
        }
    }
}

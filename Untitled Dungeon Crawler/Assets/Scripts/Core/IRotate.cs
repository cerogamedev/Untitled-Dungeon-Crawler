using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UntitledDungeonCrawler
{
    public interface IRotate  
    {
        public void IRotateTowards(Vector3 targetPosition, float rotationSpeed);
    }
}

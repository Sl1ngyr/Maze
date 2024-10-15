using System;
using Audio;
using Obstacles;
using UnityEngine;

namespace Player
{
    public class CollisionDetector : MonoBehaviour
    {
        public event Action<SoundType> OnPlayerTrapped;
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IObstacle obstacle))
            {
                OnPlayerTrapped?.Invoke(obstacle.ObstacleSound);
            }
        }
    }
}
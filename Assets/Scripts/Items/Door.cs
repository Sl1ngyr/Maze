using System;
using Configs;
using Player;
using UnityEngine;
using View;

namespace Items
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private KeysCounter _keysCounter;

        public event Action OnLevelPassed;
        
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out PlayerMovement playerMovement))
            {
                if (IsLevelPassed())
                {
                    OnLevelPassed?.Invoke();
                }
            }
        }

        private bool IsLevelPassed()
        {
            return _levelData.KeysToUnlockDoor == _keysCounter.CurrentKeys;
        }
    }
}
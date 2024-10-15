using Configs;
using Player;
using TMPro;
using UnityEngine;

namespace View
{
    public class KeysCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterKeysText;

        [SerializeField] private LevelData _levelData;
        
        [SerializeField] private string _initialText;

        [SerializeField] private PlayerPickUp _playerPickUp;
        
        public int CurrentKeys { get; private set; }

        private void Start()
        {
            _playerPickUp.OnPickedUpKey += UpdateListKeys;
        }

        private void UpdateListKeys()
        {
            CurrentKeys++;

            _counterKeysText.text = _initialText + CurrentKeys + "/" + _levelData.KeysToUnlockDoor;
        }
        
        private void OnDestroy()
        {
            _playerPickUp.OnPickedUpKey -= UpdateListKeys;
        }
    }
}
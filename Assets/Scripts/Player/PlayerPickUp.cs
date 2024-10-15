using System;
using Audio;
using Handlers;
using Items;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerPickUp : MonoBehaviour
    {
        private const float CheckPickUpDistance = 3f;
        
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private LayerMask _pickUpLayerMask;

        [SerializeField] private AudioManager _audioManager;

        private InputManager _inputManager;

        public event Action OnPickedUpKey;
        
        public void Init()
        {
            _inputManager = GetComponent<InputManager>();
            
            _inputManager.InteractionActions.PickUp.performed += PickUpItem;
        }
        
        private void PickUpItem(InputAction.CallbackContext context)
        {
            //checking whether we have a key in front of us
            if (Physics.Raycast(_cameraTransform.transform.position, _cameraTransform.transform.forward,
                    out RaycastHit raycastHit,CheckPickUpDistance, _pickUpLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ItemKey key))
                {
                    key.PickUpKey();
                    
                    OnPickedUpKey?.Invoke();
                    
                    _audioManager.PlayOneShot(SoundType.PickUpKey);
                }
            }
        }

        private void OnDestroy()
        {
            _inputManager.InteractionActions.PickUp.performed -= PickUpItem;
        }
    }
}
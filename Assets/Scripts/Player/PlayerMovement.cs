using Audio;
using Handlers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _initialSpeed;
        [SerializeField] private float _sprintSpeed;

        [SerializeField] private AudioManager _audioManager;
        
        private float _currentSpeed;
        private bool _sprinting = false;
        
        private CharacterController _characterController;
        private Vector3 _playerVelocity;

        private InputManager _inputManager;
        
        public void Init()
        {
            _inputManager = GetComponent<InputManager>();

            _inputManager.OnFootActions.Sprint.performed += Sprint;
        }
        
        public void ProcessMove(Vector2 input)
        {
            Vector3 moveDirection = Vector3.zero;
            
            moveDirection.x = input.x;
            moveDirection.z = input.y;

            _characterController.Move(transform.TransformDirection(moveDirection) * _currentSpeed * Time.deltaTime);

            if (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z) > 0)
            {
                if (!_audioManager.IsFootStepsEnable)
                {
                    _audioManager.ManageStatusFootsteps(true);
                }
            }
            else if(_audioManager.IsFootStepsEnable)
            {
                _audioManager.ManageStatusFootsteps(false);
            }
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();

            _currentSpeed = _initialSpeed;
        }
        
        private void Sprint(InputAction.CallbackContext context)
        {
            _sprinting = !_sprinting;

            _currentSpeed = _sprinting ? _sprintSpeed : _initialSpeed;
        }
        
        private void OnDestroy()
        {
            _inputManager.OnFootActions.Sprint.performed -= Sprint;
        }
    }
}
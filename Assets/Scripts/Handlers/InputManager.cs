using Player;
using UnityEngine;
using View;

namespace Handlers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PauseMenu _pauseMenu;
        
        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;
        private PlayerPickUp _playerPickUp;

        private PlayerInput _playerInput;
        
        public PlayerInput.OnFootActions OnFootActions { get; private set; }
        public PlayerInput.InteractionActions InteractionActions { get; private set; }
        public PlayerInput.SystemActions SystemActions { get; private set; }
        
        private void Awake()
        {
            _playerInput = new PlayerInput();
            OnFootActions = _playerInput.OnFoot;
            InteractionActions = _playerInput.Interaction;
            SystemActions = _playerInput.System;
            
            _playerMovement = GetComponent<PlayerMovement>();
            _playerLook = GetComponent<PlayerLook>();
            _playerPickUp = GetComponent<PlayerPickUp>();

            _playerMovement.Init();
            _playerPickUp.Init();
            _pauseMenu.Init(this);

            _pauseMenu.OnMovementActionsActivated += ActivateMovementActions;
            _pauseMenu.OnMovementActionsDeactivated += DeactivateMovementActions;
        }

        private void Update()
        {
            _playerMovement.ProcessMove(OnFootActions.Movement.ReadValue<Vector2>());
        }

        private void LateUpdate()
        {
            _playerLook.ProcessLook(OnFootActions.Look.ReadValue<Vector2>());
        }

        private void ActivateMovementActions()
        {
            OnFootActions.Enable();
            InteractionActions.Enable();
        }
        
        private void DeactivateMovementActions()
        {
            OnFootActions.Disable();
            InteractionActions.Disable();
        }
        
        private void OnEnable()
        {
            OnFootActions.Enable();
            InteractionActions.Enable();
            SystemActions.Enable();
        }

        private void OnDisable()
        {
            OnFootActions.Disable();
            InteractionActions.Disable();
            SystemActions.Disable();
        }

        private void OnDestroy()
        {
            _pauseMenu.OnMovementActionsActivated -= ActivateMovementActions;
            _pauseMenu.OnMovementActionsDeactivated -= DeactivateMovementActions;
        }
    }
}

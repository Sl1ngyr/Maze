using System;
using Handlers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace View
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _resumeButton;
        
        private InputManager _inputManager;

        public event Action OnMovementActionsDeactivated;
        public event Action OnMovementActionsActivated;
        
        public void Init(InputManager inputManager)
        {
            _inputManager = inputManager;

            _inputManager.SystemActions.Pause.performed += PauseSwitch;
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            
            UnlockCursor();
           
            OnMovementActionsDeactivated?.Invoke();
        }
        
        private void Start()
        {
            _resumeButton.onClick.AddListener(ResumeGame);
            LockCursor();
        }

        private void PauseSwitch(InputAction.CallbackContext context)
        {
            if (!_pausePanel.activeSelf)
            {
                _pausePanel.SetActive(true);
                PauseGame();
            }
            else
            {
                _pausePanel.SetActive(false);
                ResumeGame();
            }
        }

        private void ResumeGame()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            
            LockCursor();
            
            OnMovementActionsActivated?.Invoke();
        }

        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        private void OnDestroy()
        {
            _inputManager.SystemActions.Pause.performed -= PauseSwitch;
            _resumeButton.onClick.RemoveListener(ResumeGame);
        }
    }
}
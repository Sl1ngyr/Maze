using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class QuitManager : MonoBehaviour
    {
        [SerializeField] private List<Button> _quitButtons;

        private void Start()
        {
            foreach (var quitButton in _quitButtons)
            {
                quitButton.onClick.AddListener(ExitGame);
            }
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            foreach (var quitButton in _quitButtons)
            {
                quitButton.onClick.RemoveListener(ExitGame);
            }
        }
    }
}
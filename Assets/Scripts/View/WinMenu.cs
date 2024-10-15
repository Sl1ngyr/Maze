using Items;
using UnityEngine;

namespace View
{
    public class WinMenu : MonoBehaviour
    {
        [SerializeField] private Door _door;
        [SerializeField] private Color _panelColor;
        [SerializeField] private string _viewText;
        
        private UIController _uiController;
        
        private void Start()
        {
            _uiController = GetComponent<UIController>();
            
            _door.OnLevelPassed += ActivateWinMenu;
        }

        private void ActivateWinMenu()
        {
            _uiController.InitUIData(_panelColor, _viewText);
            _uiController.Show();
        }

        private void OnDestroy()
        {
            _door.OnLevelPassed -= ActivateWinMenu;
        }
    }
}
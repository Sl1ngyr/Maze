using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Image _panelView;
        [SerializeField] private TextMeshProUGUI _viewText;
        [SerializeField] private Button _restartButton;

        [SerializeField] private PauseMenu _pauseMenu;
        
        public void InitUIData(Color viewColor, string viewText)
        {
            _viewText.text = viewText;
            _panelView.color = viewColor;
        }

        public void Show()
        {
            _pauseMenu.PauseGame();
            _panelView.gameObject.SetActive(true);
        }
        
        private void Start()
        {
            _restartButton.onClick.AddListener(RestartLevel);
        }

        private void RestartLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(RestartLevel);
        }
    }
}
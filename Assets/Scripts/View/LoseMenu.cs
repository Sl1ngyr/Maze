using Audio;
using Player;
using UnityEngine;

namespace View
{
    public class LoseMenu : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private AudioManager _audioManager;
        
        [SerializeField] private Color _panelColor;
        [SerializeField] private string _viewText;

        private UIController _uiController;
        
        private void Start()
        {
            _uiController = GetComponent<UIController>();
            
            _collisionDetector.OnPlayerTrapped += ActivateLoseMenu;
        }

        private void ActivateLoseMenu(SoundType sound)
        {
            _audioManager.PlayOneShot(sound);
            _uiController.InitUIData(_panelColor,_viewText);
            _uiController.Show();
        }

        private void OnDestroy()
        {
            _collisionDetector.OnPlayerTrapped -= ActivateLoseMenu;
        }
    }
}
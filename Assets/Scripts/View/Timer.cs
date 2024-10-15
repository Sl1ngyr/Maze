using TMPro;
using UnityEngine;

namespace View
{
    public class Timer : MonoBehaviour
    {
        private const int DivisorForSeconds = 60;
        private const int PercentageForSeconds = 60;
        
        [SerializeField] private TextMeshProUGUI _timerText;

        private float _counterTimer;

        private void Update()
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            _counterTimer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(_counterTimer / DivisorForSeconds);
            int seconds = Mathf.FloorToInt(_counterTimer % PercentageForSeconds);

            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

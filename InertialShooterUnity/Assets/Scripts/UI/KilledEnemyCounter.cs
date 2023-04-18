using TMPro;
using UnityEngine;

namespace InertialShooter.UI
{
    public class KilledEnemyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _score = 0;

        public void UpdateScore()
        {
            _score++;
            _scoreText.text = _score.ToString();
        }
    }
}
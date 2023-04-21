using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI
{
    public class LooseScreenController : TimeSlower
    {
        [SerializeField] private GameObject _looseScreen;
        [SerializeField] private SceneUIController _sceneUIController;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private void Start()
        {
            _looseScreen.SetActive(false);
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(_sceneUIController.Restart);
            _quitButton.onClick.AddListener(_sceneUIController.Quit);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(_sceneUIController.Restart);
            _quitButton.onClick.RemoveListener(_sceneUIController.Quit);

            Time.timeScale = 1;
        }

        public void EnableLooseScreen()
        {
            _looseScreen.SetActive(true);
            StartCoroutine(SlowTimeSmoothly());
        }
    }
}
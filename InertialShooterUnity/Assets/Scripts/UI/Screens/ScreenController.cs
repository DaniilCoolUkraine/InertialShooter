using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.Screens
{
    public class ScreenController : TimeSlower
    {
        [SerializeField] protected GameObject _screen;
        [SerializeField] protected SceneUIController _sceneUIController;

        [SerializeField] protected Button _restartButton;
        [SerializeField] protected Button _quitButton;

        private void Start()
        {
            _screen.SetActive(false);
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

        public virtual void EnableScreen()
        {
            _screen.SetActive(true);
            StartCoroutine(SlowTimeSmoothly());
        }
    }
}
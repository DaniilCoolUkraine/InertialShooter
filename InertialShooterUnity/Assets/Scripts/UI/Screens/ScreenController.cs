using DG.Tweening;
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
        
        [SerializeField] protected Image _overlay;

        private void Start()
        {
            _screen.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            _restartButton.onClick.AddListener(_sceneUIController.Restart);
            _quitButton.onClick.AddListener(_sceneUIController.QuitToMainMenu);
        }

        protected virtual void OnDisable()
        {
            _restartButton.onClick.RemoveListener(_sceneUIController.Restart);
            _quitButton.onClick.RemoveListener(_sceneUIController.QuitToMainMenu);

            Time.timeScale = 1;
        }

        public virtual void EnableScreen()
        {
            _screen.SetActive(true);
            _overlay.DOFade(.5f, _fadeDuration);
            
            StartCoroutine(SlowTimeSmoothly());
        }
    }
}
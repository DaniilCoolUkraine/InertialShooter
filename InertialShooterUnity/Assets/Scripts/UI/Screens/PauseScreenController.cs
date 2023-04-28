using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.Screens
{
    public class PauseScreenController : ScreenController
    {
        [SerializeField] private Button _resumeButton;

        private bool _isPaused = false;

        protected override void OnEnable()
        {
            base.OnEnable();
            _resumeButton.onClick.AddListener(Resume);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _resumeButton.onClick.RemoveListener(Resume);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                    Resume();
                else
                    EnableScreen();
            }
        }

        public override void EnableScreen()
        {
            base.EnableScreen();

            _isPaused = true;
        }

        private void Resume()
        {
            _isPaused = false;
            _overlay.DOFade(0, _fadeDuration);
            _screen.SetActive(false);
            
            Time.timeScale = 1;
        }
    }
}
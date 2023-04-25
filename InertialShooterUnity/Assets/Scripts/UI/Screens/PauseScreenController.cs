using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI.Screens
{
    public class PauseScreenController : ScreenController
    {
        [SerializeField] private Button _resumeButton;

        private bool _isPaused = false;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(Resume);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(Resume);

            Time.timeScale = 1;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                    Resume();
                else
                    Pause();
            }
        }

        private void Pause()
        {
            _isPaused = true;
            _screen.SetActive(true);
            
            StartCoroutine(SlowTimeSmoothly());
        }

        private void Resume()
        {
            _isPaused = false;
            _screen.SetActive(false);
            
            Time.timeScale = 1;
        }
    }
}
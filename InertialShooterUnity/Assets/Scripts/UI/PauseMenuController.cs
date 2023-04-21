using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI
{
    public class PauseMenuController : TimeSlower
    {
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private SceneUIController _sceneUIController;

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private bool _isPaused = false;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(Resume);
            _restartButton.onClick.AddListener(_sceneUIController.Restart);
            _quitButton.onClick.AddListener(_sceneUIController.Quit);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(Resume);
            _restartButton.onClick.RemoveListener(_sceneUIController.Restart);
            _quitButton.onClick.RemoveListener(_sceneUIController.Quit);

            Time.timeScale = 1;
        }

        private void Start()
        {
            _pauseScreen.SetActive(false);
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
            _pauseScreen.SetActive(true);
            StartCoroutine(SlowTimeSmoothly());
        }

        private void Resume()
        {
            _isPaused = false;
            _pauseScreen.SetActive(false);
            
            Debug.Log(Time.timeScale);
            
            Time.timeScale = 1;
            
            Debug.Log(Time.timeScale);
        }
    }
}
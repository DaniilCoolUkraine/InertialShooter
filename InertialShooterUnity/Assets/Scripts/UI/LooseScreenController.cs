using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace InertialShooter.UI
{
    public class LooseScreenController : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration;
        
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
            Time.timeScale = 1;
        }

        public void EnableLooseScreen()
        {
            _looseScreen.SetActive(true);
            StartCoroutine(SlowTimeSmoothly());
        }

        private IEnumerator SlowTimeSmoothly()
        {
            float elapsed = 0;
            while (elapsed < _fadeDuration)
            {
                Time.timeScale = Mathf.Lerp(1, 0, elapsed / _fadeDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            Time.timeScale = 0;
        }
    }
}
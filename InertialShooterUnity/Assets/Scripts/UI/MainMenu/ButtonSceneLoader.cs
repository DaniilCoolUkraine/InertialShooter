using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InertialShooter.UI.MainMenu
{
    public class ButtonSceneLoader : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private string _scene;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene()
        {
            if (string.IsNullOrEmpty(_scene))
            {
                Debug.Log("quit");
                Application.Quit();
                return;
            }
            SceneManager.LoadScene(_scene);
        }
    }
}
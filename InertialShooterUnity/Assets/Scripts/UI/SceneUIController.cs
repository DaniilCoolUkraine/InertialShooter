using UnityEngine;
using UnityEngine.SceneManagement;

namespace InertialShooter.UI
{
    public class SceneUIController : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void QuitToMainMenu()
        {
            LoadScene("MainMenuScene");
        }
        
        private void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
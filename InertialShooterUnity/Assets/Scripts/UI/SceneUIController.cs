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

        public void Quit()
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}
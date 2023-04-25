using System.Collections;
using UnityEngine;

namespace InertialShooter.UI.Screens
{
    public class TimeSlower : MonoBehaviour
    {
        [SerializeField] protected float _fadeDuration;

        protected IEnumerator SlowTimeSmoothly()
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
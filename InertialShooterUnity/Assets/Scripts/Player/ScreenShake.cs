using System.Collections;
using Cinemachine;
using UnityEngine;

namespace InertialShooter.Player
{
    public class ScreenShake : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        [SerializeField] private float _amplitude;
        [SerializeField] private float _time;

        public void Shake(Vector2 direction)
        {
            StartCoroutine(CameraShake());
        }

        private IEnumerator CameraShake()
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _amplitude;

            yield return new WaitForSeconds(_time);
            
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }
    }
}
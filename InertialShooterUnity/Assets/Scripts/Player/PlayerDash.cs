using System.Collections;
using DG.Tweening;
using InertialShooter.General;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerDash : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private ParticleSystem _speedParticles;

        [SerializeField] private float _strechDuration;
        
        private Vector3 _startScale;
        private float _recoil;
        
        public void Dash(Vector2 direction)
        {
            _rb.AddForce(direction * _recoil, ForceMode2D.Impulse);

            StartCoroutine(Strech(direction));

            if (!_speedParticles.isPlaying)
                _speedParticles.Play();
        }

        private void Update()
        {
            if (!_speedParticles.isPlaying)
                return;

            if (_rb.velocity.magnitude < 8)
                _speedParticles.Stop();
        }

        public void SetRecoil(float recoil)
        {
            _recoil = recoil;
        }

        private IEnumerator Strech(Vector2 direction)
        {
            _startScale = transform.localScale;
            Vector3 absoluteDirection = HelperFunctions.VectorAbs(direction);

            Vector3 dashScale =
                HelperFunctions.VectorDivision(absoluteDirection, absoluteDirection + new Vector3(0.03f, 0.03f, 0.03f))
                    .normalized;

            transform.DOScale(dashScale, _strechDuration);
            yield return new WaitForSeconds(_strechDuration);
            transform.DOScale(_startScale, _strechDuration);
        }
    }
}
using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Health events")]
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DamageIndicator _indicator;

        [Header("Shoot events")]
        [SerializeField] private PlayerShoot _playerShoot;
        [SerializeField] private BulletTracer _tracer;
        [SerializeField] private PlayerDash _dash;

        private void OnEnable()
        {
            _playerHealth.OnDamaged += _indicator.ColorTint;
            _playerShoot.OnShoot += _tracer.CreateTrace;
            _playerShoot.OnShoot += _dash.Dash;
        }

        private void OnDisable()
        {
            _playerHealth.OnDamaged -= _indicator.ColorTint;
            _playerShoot.OnShoot -= _tracer.CreateTrace;
            _playerShoot.OnShoot -= _dash.Dash;
        }
    }
}
using System;
using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DamageIndicator _indicator;

        [SerializeField] private PlayerShoot _playerShoot;
        [SerializeField] private BulletTracer _tracer;

        private void OnEnable()
        {
            _playerHealth.OnDamaged += _indicator.ColorTint;
            _playerShoot.OnShoot += _tracer.CreateTrace;
        }

        private void OnDisable()
        {
            _playerHealth.OnDamaged -= _indicator.ColorTint;
            _playerShoot.OnShoot -= _tracer.CreateTrace;
        }
    }
}
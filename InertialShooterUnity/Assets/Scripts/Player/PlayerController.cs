using System;
using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DamageIndicator _indicator;

        private void OnEnable()
        {
            _playerHealth.OnDamaged += _indicator.ColorTint;
        }

        private void OnDisable()
        {
            _playerHealth.OnDamaged -= _indicator.ColorTint;
        }
    }
}
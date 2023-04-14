using System.Collections;
using UnityEngine;

namespace InertialShooter.Damageable
{
    public class PlayerHealth : Health
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _minimumVelocity;

        [SerializeField] private float _invincibilityTime = 0.5f;

        private bool _canBeDamaged = true;
        private bool _isInvincible = false;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                _canBeDamaged = CanBeDamaged();

                if (_canBeDamaged)
                {
                    TakeDamage(1);
                    StartCoroutine(InvincibilityCoroutine());
                }
            }
        }

        private bool CanBeDamaged()
        {
            if (_isInvincible)
                return false;
            
            if (_rb.velocity.magnitude <= _minimumVelocity)
                return true;
            
            return false;
        }

        private IEnumerator InvincibilityCoroutine()
        {
            _canBeDamaged = false;
            _isInvincible = true;
            
            yield return new WaitForSeconds(_invincibilityTime);
            
            _isInvincible = false;
            _canBeDamaged = true;
        }
    }
}
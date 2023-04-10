using UnityEngine;

namespace InertialShooter.Damageable
{
    public class PlayerHealth : Health
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _minimumVelocity;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                if (_rb.velocity.magnitude <= _minimumVelocity)
                {
                    TakeDamage(1);
                }
            }
        }
    }
}
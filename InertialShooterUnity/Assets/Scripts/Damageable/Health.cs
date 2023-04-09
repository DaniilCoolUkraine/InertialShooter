using System;
using UnityEngine;

namespace InertialShooter.Damageable
{
    public class Health : MonoBehaviour, IDamageable
    {
        public event Action OnDamaged;
        
        [SerializeField] private int _health;
        [SerializeField] private ParticleSystem _dieParticles;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            OnDamaged?.Invoke();

            if (_health<=0)
            {
                Die();
            }
        }

        public void Die()
        {
            ParticleSystem particles = Instantiate(_dieParticles, transform);
            
            Destroy(particles, particles.main.duration);
            Destroy(gameObject, particles.main.duration);
        }
    }
}
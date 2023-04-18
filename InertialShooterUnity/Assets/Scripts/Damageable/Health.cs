using System;
using UnityEngine;

namespace InertialShooter.Damageable
{
    public class Health : MonoBehaviour, IDamageable
    {
        public event Action OnDamaged;
        public event Action OnDie;

        [SerializeField] private int _health;
        [SerializeField] private ParticleSystem _dieParticles;

        public void TakeDamage(int damage)
        {
            _health -= damage;
            OnDamaged?.Invoke();

            var particles = Instantiate(_dieParticles, transform.position, Quaternion.identity);
            particles.Play();

            Destroy(particles.gameObject, particles.main.duration);

            if (_health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
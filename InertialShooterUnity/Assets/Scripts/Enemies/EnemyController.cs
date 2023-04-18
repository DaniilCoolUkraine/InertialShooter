using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private Health _enemyHealth;

        private EnemyManager _enemyManager;
        
        public void Initialize(Transform target, EnemyManager enemyManager)
        {
            _enemyMovement.SetTarget(target);
            _enemyManager = enemyManager;
            
            _enemyHealth.OnDie += _enemyManager.OnEnemyDie;
        }

        private void OnDisable()
        {
            _enemyHealth.OnDie -= _enemyManager.OnEnemyDie;
        }
    }
}
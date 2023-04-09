using UnityEngine;
using UnityEngine.AI;

namespace InertialShooter.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private Transform _target;

        private void Awake()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        private void Start()
        {
            _agent.speed = Random.Range(1, 10);
        }

        private void Update()
        {
            if (_target != null)
            {
                _agent.SetDestination(_target.position);
            }
        }

        public void Initialize(Transform target)
        {
            _target = target;
        }
    }
}
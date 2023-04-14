using System.Collections;
using UnityEngine;

namespace InertialShooter.Enemies.Spawner
{
    public class EnemyWaveSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private GameObject _enemy;

        [Space(10)] 
        [SerializeField] private Transform[] _spawningSpots;

        [Space(10)] 
        
        [Min(0.1f)] 
        [SerializeField] private float _timeBetweenSpawn = 1;

        private void Start()
        {
            StartCoroutine(CreateEnemiesOnScene());
        }

        private IEnumerator CreateEnemiesOnScene()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBetweenSpawn);

                EnemyMovement enemyMove =
                    Instantiate(_enemy, _spawningSpots[Random.Range(0, _spawningSpots.Length)].position,
                        Quaternion.identity).GetComponent<EnemyMovement>();
                enemyMove.Initialize(_playerTransform);
            }
        }
    }
}
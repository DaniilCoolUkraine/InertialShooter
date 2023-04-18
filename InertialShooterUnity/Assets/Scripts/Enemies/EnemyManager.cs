using InertialShooter.ScriptableObjects;
using UnityEngine;

namespace InertialShooter.Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EventSO _onEnemyKilled;
        
        public void OnEnemyDie()
        {
            _onEnemyKilled.Invoke();
        }
    }
}
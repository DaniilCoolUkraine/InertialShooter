using InertialShooter.ScriptableObjects;
using UnityEngine;

namespace InertialShooter.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private EventSO _onEnemyKilled;

        [SerializeField] private KilledEnemyCounter _enemyCounter;

        private void OnEnable()
        {
            _onEnemyKilled.OnInvoked += _enemyCounter.UpdateScore;
        }

        private void OnDisable()
        {
            _onEnemyKilled.OnInvoked -= _enemyCounter.UpdateScore;
        }
    }
}
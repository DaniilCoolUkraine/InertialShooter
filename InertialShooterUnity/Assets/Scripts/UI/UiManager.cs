using InertialShooter.ScriptableObjects;
using UnityEngine;

namespace InertialShooter.UI
{
    public class UiManager : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private EventSO _onEnemyKilled;
        [SerializeField] private EventSO _onPlayerDie;

        [Header("Ui controllers")]
        [SerializeField] private KilledEnemyCounter _enemyCounter;
        [SerializeField] private LooseScreenController _looseScreen;

        private void OnEnable()
        {
            _onEnemyKilled.OnInvoked += _enemyCounter.UpdateScore;
            _onPlayerDie.OnInvoked += _looseScreen.EnableLooseScreen;
        }

        private void OnDisable()
        {
            _onEnemyKilled.OnInvoked -= _enemyCounter.UpdateScore;
            _onPlayerDie.OnInvoked -= _looseScreen.EnableLooseScreen;
        }
    }
}
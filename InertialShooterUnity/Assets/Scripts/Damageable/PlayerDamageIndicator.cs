using UnityEngine;

namespace InertialShooter.Damageable
{
    public class PlayerDamageIndicator : DamageIndicator
    {
        [SerializeField] private Sprite[] _playerDamagedState;

        private int _currentState = 0;

        public override void Indicate()
        {
            base.Indicate();
            if (++_currentState < _playerDamagedState.Length)
            {
                _sprite.sprite = _playerDamagedState[_currentState];
            }
        }
    }
}
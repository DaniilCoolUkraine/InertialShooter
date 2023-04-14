using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace InertialShooter.Damageable
{
    public class DamageIndicator : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _sprite;

        [SerializeField] private Color _damagedColor;

        [SerializeField] private float _duration;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = _sprite.color;
        }

        public virtual void Indicate()
        {
            StartCoroutine(ColorTintCoroutine());
        }

        private IEnumerator ColorTintCoroutine()
        {
            if (_sprite != null)
            {
                _sprite.DOColor(_damagedColor, _duration);
                yield return new WaitForSeconds(_duration);
                _sprite.DOColor(_defaultColor, _duration);
            }
        }
    }
}
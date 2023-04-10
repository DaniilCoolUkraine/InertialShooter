using DG.Tweening;
using UnityEngine;

namespace InertialShooter.Player
{
    public class PlayerReloadIndicator : MonoBehaviour
    {
        [SerializeField] private Transform _indicatorTransform;

        Vector3 _startScale;

        private void Awake()
        {
            _startScale = _indicatorTransform.localScale;
        }

        public void OnReload(float duration)
        {
            if (_indicatorTransform != null)
            {
                _indicatorTransform.localScale = Vector3.zero;
                _indicatorTransform.DOScale(_startScale, duration);
            }
        }
    }
}
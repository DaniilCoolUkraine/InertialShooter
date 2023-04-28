using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Chips.Weapons.ShootFunctions
{
    [CreateAssetMenu(fileName = "ShootgunShootSO", menuName = "ScriptableObjects/ShootgunShootSO", order = 0)]
    public class ShootgunShootFunctionSO : ShootFunctionSO
    {
        [SerializeField] private float _shootSize;

        private Vector2 _size;
        
        private void Awake()
        {
            _size  = new Vector2(_shootSize, _shootSize);
        }
        
        public override void Shoot(Vector3 position, Vector3 direction, float shootDistance, string[] shootLayers)
        {
            RaycastHit2D[] hits = Physics2D.BoxCastAll(position, _size, 0, -direction, shootDistance,
                LayerMask.GetMask(shootLayers));

            if (hits.Length > 0)
            {
                foreach (var hit in hits)
                {
                    IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            
                    if (damageable == null)
                        break;
                    damageable.TakeDamage(1);
                }
            }
        }
    }
}
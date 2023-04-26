using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Chips.Weapons.ShootFunctions
{
    [CreateAssetMenu(fileName = "RailgunShootSO", menuName = "ScriptableObjects/RailgunShootSO", order = 0)]
    public class RailgunShootFunctionSO : ShootFunctionSO
    {
        public override void Shoot(Vector3 position, Vector3 direction, float shootDistance, string[] shootLayers)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(position, -direction, shootDistance,
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
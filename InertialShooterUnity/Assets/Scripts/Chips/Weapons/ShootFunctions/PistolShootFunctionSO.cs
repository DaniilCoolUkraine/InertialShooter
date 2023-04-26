using InertialShooter.Damageable;
using UnityEngine;

namespace InertialShooter.Chips.Weapons.ShootFunctions
{
    [CreateAssetMenu(fileName = "PistolShootSO", menuName = "ScriptableObjects/PistolShootSO", order = 0)]
    public class PistolShootFunctionSO : ShootFunctionSO
    {
        public override void Shoot(Vector3 position, Vector3 direction, float shootDistance, string[] shootLayers)
        {
            RaycastHit2D hit = Physics2D.Raycast(position, -direction, shootDistance,
                LayerMask.GetMask(shootLayers));

            if (hit.collider == null)
                return;
            
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();

            if (damageable == null)
                return;
            
            damageable.TakeDamage(1);
        }
    }
}
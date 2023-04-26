using UnityEngine;

namespace InertialShooter.Chips.Weapons.ShootFunctions
{
    public abstract class ShootFunctionSO : ScriptableObject
    {
        public abstract void Shoot(Vector3 position, Vector3 direction, float shootDistance, string[] shootLayers);
    }
}
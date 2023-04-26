using InertialShooter.Chips.ScriptableObjects;
using InertialShooter.Chips.Weapons.ShootFunctions;
using UnityEngine;

namespace InertialShooter.Chips.Weapons
{
    [CreateAssetMenu(fileName = "WeaponChipDataSO", menuName = "ScriptableObjects/WeaponChipDataSO", order = 0)]
    public class WeaponChipDataSO : ChipDataSO
    {
        [SerializeField] private float _recoil;
        [SerializeField] private float _shootDistance;
        
        [SerializeField] private string[] _shootLayers;

        [SerializeField] private ShootFunctionSO _shootFunction;
        
        public float Recoil => _recoil;
        public float ShootDistance => _shootDistance;
        
        public string[] ShootLayers => _shootLayers;
        
        public ShootFunctionSO ShootFunction => _shootFunction;
    }
}
using UnityEngine;

namespace InertialShooter.Chips.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponChipDataSO", menuName = "ScriptableObjects/WeaponChipDataSO", order = 0)]
    public class WeaponChipDataSO : ChipDataSO
    {
        [SerializeField] private float _recoil;
        [SerializeField] private float _shootDistance;
        
        [SerializeField] private string[] _shootLayers;


        public float Recoil => _recoil;
        public float ShootDistance => _shootDistance;
        
        public string[] ShootLayers => _shootLayers;
    }
}
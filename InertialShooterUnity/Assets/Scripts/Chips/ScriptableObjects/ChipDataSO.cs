using UnityEngine;

namespace InertialShooter.Chips.ScriptableObjects
{
    public abstract class ChipDataSO : ScriptableObject
    {
        [SerializeField] private float _cooldown;

        public float Cooldown => _cooldown;
    }
}
using InertialShooter.Chips.ScriptableObjects;
using UnityEngine;

namespace InertialShooter.Chips
{
    public abstract class Chip : MonoBehaviour
    {
        [SerializeField] protected ChipDataSO _chipData;
    }
}
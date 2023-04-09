using InertialShooter.Damageable;
using UnityEditor;
using UnityEngine;

namespace InertialShooter.Editor
{
    [CustomEditor(typeof(Health))]
    public class HealthEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Health health = (Health) target;
            
            if (GUILayout.Button("Die"))
            {
                health.Die();
            }
        }
    }
}
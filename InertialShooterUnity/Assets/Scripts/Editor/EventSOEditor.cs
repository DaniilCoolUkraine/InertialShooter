using InertialShooter.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace InertialShooter.Editor
{
    [CustomEditor(typeof(EventSO))]
    public class EventSOEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EventSO eventSO = (EventSO) target;

            if (GUILayout.Button("Invoke"))
            {
                eventSO.Invoke();
            }
        }
    }
}
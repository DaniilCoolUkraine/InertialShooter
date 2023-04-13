using UnityEngine;

namespace InertialShooter.General
{
    public class HelperFunctions
    {
        public static Vector3 VectorAbs(Vector3 vector)
        {
            float x = Mathf.Abs(vector.x);
            float y = Mathf.Abs(vector.y);
            float z = Mathf.Abs(vector.z);

            return new Vector3(x, y, z);
        }

        public static Vector3 VectorDivision(Vector3 firstVector, Vector3 secondVector)
        {
            float x = firstVector.x / secondVector.x;
            float y = firstVector.y / secondVector.y;
            float z = firstVector.z / secondVector.z;
            
            return new Vector3(x, y, z);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovaUtils
{
    public static class NovaUtilities
    {
        public static float Vector2Distance(Vector2 v1, Vector2 v2)
        {
            float result = Mathf.Sqrt((v1.x - v2.x) * (v1.x - v2.x)
                                     + (v1.y - v2.y) * (v1.y - v2.y));
            return result;
        }
        public static float Vector3Distance(Vector3 v1, Vector3 v2)
        {
            float result = Mathf.Sqrt((v1.x - v2.x) * (v1.x - v2.x)
                                     + (v1.y - v2.y) * (v1.y - v2.y)
                                     + (v1.z - v2.z) * (v1.z - v2.z));
            return result;
        }
    }
}

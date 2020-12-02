using FlatBuffers;
using TestData;
using UnityEngine;

namespace Exensions
{
    public static class Vector3Extension
    {
        public static Vector3 ToVector3(this Vec3 vec3)
        {
            return new Vector3(vec3.X, vec3.Y, vec3.Z);
        }

        public static Offset<Vec3> ToVec3Offset(this Vector3 vector3, FlatBufferBuilder builder)
        {
            return Vec3.CreateVec3(builder, vector3.x, vector3.y, vector3.z);
        }
    }
}

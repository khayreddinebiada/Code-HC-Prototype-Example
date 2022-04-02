using UnityEngine;

namespace Main
{
    public interface IBlow
    {
        bool allow { get; set; }

        Vector3 BlowForce(Vector3 direction, float magnitude);
    }
}
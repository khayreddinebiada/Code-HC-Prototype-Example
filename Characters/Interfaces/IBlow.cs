using UnityEngine;

namespace Main
{
    public interface IBlow : IGamePause
    {
        bool isEnable { get; set; }

        bool TryGetBlowForce(Vector3 direction, float sqrMagnitude, out Vector3 result);
    }
}
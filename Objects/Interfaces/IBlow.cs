using UnityEngine;

namespace Main
{
    public interface IBlow : IGamePause
    {
        bool isEnable { get; set; }

        void MakePause(bool isPause);

        Vector3 BlowForce(Vector3 direction, float magnitude);
    }
}
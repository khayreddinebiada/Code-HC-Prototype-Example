using UnityEngine;

namespace Main
{
    public interface IHead : IGoalHandler, IGamePause
    {
        void LookAt(Vector3 forward);

        void OnBlowed();
    }
}
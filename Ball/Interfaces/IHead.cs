using UnityEngine;

namespace Main
{
    public interface IHead
    {
        void LookAt(Vector3 forward);

        void OnBlowed();
    }
}
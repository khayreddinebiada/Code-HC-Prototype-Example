using UnityEngine;

namespace main
{
    public interface IHead
    {
        void Initialize(Ball ball);

        void MakeBlow(Vector3 direction);
    }
}
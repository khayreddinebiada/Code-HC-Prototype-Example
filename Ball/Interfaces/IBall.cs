using UnityEngine;

public interface IBall
{
    Vector3 position { get; }

    Vector3 velocity { get; }

    void AddForce(Vector3 force);
}

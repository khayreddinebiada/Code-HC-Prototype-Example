using UnityEngine;

public interface IBall
{
    Vector3 position { get; }

    void AddForce(Vector3 force);
}

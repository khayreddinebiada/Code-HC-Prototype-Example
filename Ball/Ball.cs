using UnityEngine;

namespace main
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_Rigidbody;

        public void AddForce(Vector3 direction, float forceAmount)
        {
            m_Rigidbody.AddForce(direction.normalized * forceAmount);
        }
    }
}

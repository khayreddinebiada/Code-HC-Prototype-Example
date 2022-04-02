using UnityEngine;

namespace Main
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_Rigidbody;

        public Vector3 position => transform.position;

        public void AddForce(Vector3 force)
        {
            m_Rigidbody.velocity += force;
        }
    }
}

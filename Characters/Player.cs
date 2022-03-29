using UnityEngine;

namespace main
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected Head m_Head;

        protected Ball m_Ball = null;

        public void Initialize(Ball ball)
        {
            m_Head.Initialize(m_Ball = ball ?? throw new System.ArgumentNullException());
        }
    }
}

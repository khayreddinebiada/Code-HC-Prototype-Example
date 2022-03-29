using UnityEngine;

namespace main
{
    [System.Serializable]
    public struct Head : IHead
    {
        [SerializeField] private float m_ForceValue;

        private IBlow m_Blow;

        public void Initialize(Ball ball)
        {
            m_Blow = new Blow(ball, m_ForceValue);
        }

        public void MakeBlow(Vector3 direction)
        {
            m_Blow.MakeBlow(direction);
        }
    }
}

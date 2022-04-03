using UnityEngine;

namespace Main
{
    [System.Serializable]
    public struct AgentBlow : IBlow
    {
        public float m_ForceValue;
        public float m_Radio;

        public bool isEnable { get; set; }

        public bool TryGetBlowForce(Vector3 direction, float sqrMagnitude, out Vector3 result)
        {
            if (sqrMagnitude <= m_Radio)
            {
                result = direction * m_ForceValue;
                return true;
            }

            result = Vector3.zero;
            return false;
        }

        public void OnGamePause(bool isPause)
        {
            isEnable = !isPause;
        }
    }
}

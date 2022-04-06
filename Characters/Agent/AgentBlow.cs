using UnityEngine;

namespace Main
{
    [System.Serializable]
    public class AgentBlow : IBlow
    {
        public string name;
        public float forceValue;
        public float radio;

        public bool isEnable { get; set; }

        public bool TryGetBlowForce(Vector3 direction, float sqrMagnitude, out Vector3 result)
        {
            if (sqrMagnitude <= radio)
            {
                result = direction * forceValue;
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

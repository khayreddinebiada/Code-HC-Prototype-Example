using UnityEngine;

namespace Main
{
    [System.Serializable]
    public class AgentBrain : IAgentBrain
    {
        public LayerMask myGoal;
        public LayerMask otherGoal;

        public float blowEvery;
        public Vector3 myForward;



        public float blowMultiply => throw new System.NotImplementedException();

        public bool AllowBlow()
        {
            return false;
        }
    }
}

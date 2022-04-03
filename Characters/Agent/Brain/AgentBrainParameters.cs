using UnityEngine;

namespace Main
{
    public struct AgentBrainParameters
    {
        public Vector3 ballPosition;
        public Vector3 agentPosition;
        public float lastTimeBlowed;

        public AgentBrainParameters(Vector3 agentPosition, Vector3 ballPosition, float lastTimeBlowed)
        {
            this.ballPosition = ballPosition;
            this.agentPosition = agentPosition;
            this.lastTimeBlowed = lastTimeBlowed;
        }
    }
}

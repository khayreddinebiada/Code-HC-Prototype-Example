using UnityEngine;

namespace Main
{
    [System.Serializable]
    public class EasyBrain : IAgentBrain
    {
        public float angleRange = 120;
        public Vector3 myForward;
        public Vector2 blowTimeRange = new Vector2(2, 4);


        public bool AllowBlow(AgentBrainParameters parameters)
        {
            Vector3 value = parameters.ballPosition - parameters.agentPosition;
            float forwardAngle = Vector3.Angle(value, myForward);

            return forwardAngle < angleRange && parameters.lastTimeBlowed + Random.Range(blowTimeRange.x, blowTimeRange.y) <= Time.time;
        }
    }
}

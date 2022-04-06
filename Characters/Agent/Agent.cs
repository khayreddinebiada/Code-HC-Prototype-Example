using UnityEngine;

namespace Main
{
    public class Agent : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings _settings;
        [SerializeField] private AgentHead m_AgentHead;


        private IAgentBrain m_Brain;

        private float lastTimeBlow = 0;


        protected override void OnInitialiazed()
        {
            SetBrain(_settings.easyBrain);

            m_Manager.SubscribeGoalHandler(m_Head);

            m_Manager.SubscribeGamePauser(m_Head);
            m_Manager.SubscribeGamePauser(m_Blow);
        }

        public void SetBrain(IAgentBrain brain)
        {
            m_Brain = brain;
        }

        private void Update()
        {
            if (!m_Blow.isEnable) return;

            if (m_Brain.AllowBlow(new AgentBrainParameters(m_Ball.position, transform.position, lastTimeBlow)))
            {
                bool isBlowing = MakeBlow();

                if (isBlowing) lastTimeBlow = Time.time;
            }
        }

        protected override IBlow DefineBlow()
        {
            return _settings.AgentBlow[id];
        }

        protected override IHead DefineHead()
        {
            m_AgentHead.Initialize();
            return m_AgentHead;
        }
    }
}

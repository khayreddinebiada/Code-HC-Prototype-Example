using UnityEngine;

namespace Main
{
    public partial class Agent : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings _settings;
        [SerializeField] private AgentHead m_AgentHead;


        [SerializeField] private EasyBrain m_EasyBrain;
        [SerializeField] private EasyBrain m_MediumBrain;
        [SerializeField] private EasyBrain m_HardBrain;

        private IAgentBrain m_Brain;

        private float lastTimeBlow = 0;


        protected override void OnInitialiazed()
        {
            m_Brain = DefineBrain();

            m_Manager.SubscribeGoalHandler(m_Head);

            m_Manager.SubscribeGamePauser(m_Head);
            m_Manager.SubscribeGamePauser(m_Blow);
        }

        private IAgentBrain DefineBrain()
        {
            switch (_settings.m_Difficulty)
            {
                case AgentDifficulty.Easy: return m_EasyBrain;
                case AgentDifficulty.Medium: return m_MediumBrain;
                case AgentDifficulty.Hard: return m_HardBrain;
            }

            return m_EasyBrain;
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
            return _settings.AgentBlow;
        }

        protected override IHead DefineHead()
        {
            m_AgentHead.Initialize();
            return m_AgentHead;
        }
    }
}

using UnityEngine;

namespace Main
{
    public partial class Agent : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings _settings;

        [SerializeField] private AgentHead m_AgentHead;
        [SerializeField] private AgentBrain _brain;

        private IAgentBrain m_Brain;

        protected override void OnInitialiazed()
        {
            m_Manager.SubscribeGoalHandler(m_Head);

            m_Manager.SubscribeGamePauser(m_Head);
            m_Manager.SubscribeGamePauser(m_Blow);

            m_Brain = _brain;
        }

        private void Update()
        {
            if (!m_Blow.isEnable) return;

            if (m_Brain.AllowBlow()) MakeBlow();
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

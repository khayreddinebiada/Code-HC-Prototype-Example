using UnityEngine;

namespace Main
{
    public partial class Agent : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings _settings;

        [SerializeField] private AgentHead m_AgentHead;
        [SerializeField] private AgentBrain _brain;

        private IAgentBrain m_Brain;

        private void Start()
        {
            m_Brain = _brain;
        }

        private void Update()
        {
            if (!m_Blow.allow) return;

            if (m_Brain.AllowBlow()) MakeBlow();
        }

        protected override IBlow DefineBlow()
        {
            return _settings.blowAgent;
        }

        protected override IHead DefineHead()
        {
            m_AgentHead.Initialize();
            return m_AgentHead;
        }

        protected override IGoalHandler DefineGoalHandler()
        {
            return m_AgentHead;
        }
    }
}

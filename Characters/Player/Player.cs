using UnityEngine;

namespace Main
{
    public partial class Player : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings m_Settings;

        [SerializeField] private PlayerHead m_PlayerHead;

        protected override IBlow DefineBlow()
        {
            return m_Settings.blowPlayer;
        }

        protected override IGoalHandler DefineGoalHandler()
        {
            return m_PlayerHead;
        }

        protected override IHead DefineHead()
        {
            m_PlayerHead.Initialize();
            return m_PlayerHead;
        }
    }
}

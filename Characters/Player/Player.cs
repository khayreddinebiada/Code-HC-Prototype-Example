using UnityEngine;

namespace Main
{
    public partial class Player : CharacterBehaviour
    {
        [SerializeField] private CharacterSettings m_Settings;

        [SerializeField] private PlayerHead m_PlayerHead;

        protected override void OnInitialiazed()
        {
            m_Manager.SubscribeGoalHandler(m_Head);

            m_Manager.SubscribeGamePauser(m_Head);
            m_Manager.SubscribeGamePauser(m_Blow);


            m_Blow.isEnable = true;
        }

        protected override IBlow DefineBlow()
        {
            return m_Settings.PlayerBlow;
        }

        protected override IHead DefineHead()
        {
            m_PlayerHead.Initialize();
            return m_PlayerHead;
        }
    }
}

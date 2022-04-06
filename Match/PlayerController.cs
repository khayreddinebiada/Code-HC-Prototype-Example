using Input;
using Physic;
using UnityEngine;

namespace Main
{
    public sealed class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// To detect the player component where the player clicks, and add the clicking logic there.
        /// </summary>
        [System.Serializable]
        private class ClickerDetecter : IClick
        {
            [SerializeField] private Camera m_Camera;
            [SerializeField] private LayerMask m_PlayerMask;

            /// <summary>
            /// When the player click on the screen we call this function.
            /// </summary>
            /// <param name="data"> Input Info </param>
            public void OnClick(InputInfo data)
            {
                Player player = RaycastHits.GetColliderHitedRaycast<Player>(m_Camera, data.currentPosition, m_PlayerMask);
                if (player != null) player.MakeBlow();
            }
        }

        [SerializeField] private ClickerDetecter m_ClickerDetecter;

        private void OnEnable()
        {
            InputEvents.Click.Subscribe(m_ClickerDetecter);
        }

        private void OnDisable()
        {
            InputEvents.Click.Unsubscribe(m_ClickerDetecter);
        }
    }
}
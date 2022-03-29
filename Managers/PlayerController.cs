using input;
using physic;
using UnityEngine;

namespace main
{
    public sealed class PlayerController : MonoBehaviour
    {
        [System.Serializable]
        private class ClickerDetecter : IClick
        {
            [SerializeField] private Camera m_Camera;
            [SerializeField] private LayerMask m_PlayerMask;

            public void OnClick(InputInfo data)
            {
                Debug.Log("RaycastHits value: " + RaycastHits.GetColliderHitedRaycast<Player>(m_Camera, data.point, m_PlayerMask));
            }
        }

        [SerializeField] private ClickerDetecter m_ClickerDetecter;

        private void OnEnable()
        {
            InputEvents.SubscribeClick(m_ClickerDetecter);
        }

        private void OnDisable()
        {
            InputEvents.UnsubscribeClick(m_ClickerDetecter);
        }
    }
}
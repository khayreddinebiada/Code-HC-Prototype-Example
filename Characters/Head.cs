using UnityEngine;

namespace Main
{
    [System.Serializable]
    public abstract class Head : IHead
    {
        [SerializeField] protected Transform m_Body;
        [SerializeField] protected Animator m_Animator;

        public void Initialize()
        {
            //m_Animator.Play("Start", 0, 0.25f);
        }

        public void LookAt(Vector3 lookAt)
        {
            m_Body.forward = lookAt;
        }

        public void OnBlowed()
        {
            //m_Animator.Play("Blow", 0, 0.25f);
        }

        public abstract void OnGamePause(bool isPause);

        public abstract void OnGoalMaded();
    }
}

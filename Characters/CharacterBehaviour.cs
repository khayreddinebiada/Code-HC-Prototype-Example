using UnityEngine;

namespace Main
{
    public abstract class CharacterBehaviour : MonoBehaviour
    {
        protected IMatchManager m_Manager;

        protected IBlow m_Blow;
        protected IHead m_Head;

        protected IBall m_Ball = null;

        public void Initialize(IMatchManager manager, IBall ball)
        {
            m_Manager = manager ?? throw new System.NullReferenceException();

            m_Ball = ball ?? throw new System.NullReferenceException();

            m_Head = DefineHead();

            m_Blow = DefineBlow();

            OnInitialiazed();
        }

        protected abstract void OnInitialiazed();

        protected abstract IBlow DefineBlow();

        protected abstract IHead DefineHead();

        public virtual void MakeBlow()
        {
            if (!m_Blow.isEnable) return;

            Vector3 direction = (transform.position - m_Ball.position);
            float magnitude = direction.magnitude;
            direction = -new Vector3(direction.x, 0, direction.z) / magnitude;

            m_Ball.AddForce(m_Blow.BlowForce(direction, magnitude));

            m_Head.LookAt(direction);
            m_Head.OnBlowed();
        }
    }
}

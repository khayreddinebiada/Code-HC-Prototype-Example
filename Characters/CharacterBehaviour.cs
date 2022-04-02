using UnityEngine;

namespace Main
{
    public abstract class CharacterBehaviour : MonoBehaviour
    {
        protected IMatchManager m_Manager;

        protected IBlow m_Blow;
        protected IHead m_Head;

        protected Ball m_Ball = null;

        public void Initialize(IMatchManager manager, Ball ball)
        {
            m_Manager = manager ?? throw new System.NullReferenceException();

            m_Ball = ball ?? throw new System.NullReferenceException();

            m_Head = DefineHead();

            m_Blow = DefineBlow();

            m_Manager.Subscribe(DefineGoalHandler());
        }

        protected abstract IBlow DefineBlow();

        protected abstract IHead DefineHead();

        protected abstract IGoalHandler DefineGoalHandler();

        public virtual void MakeBlow()
        {
            if (!m_Blow.allow) return;

            Vector3 direction = (transform.position - m_Ball.position);
            float magnitude = direction.magnitude;
            direction = -new Vector3(direction.x, 0, direction.z) / magnitude;

            m_Ball.AddForce(m_Blow.BlowForce(direction, magnitude));

            m_Head.LookAt(direction);
            m_Head.OnBlowed();
        }
    }
}

using UnityEngine;

namespace Main
{
    public abstract class CharacterBehaviour : MonoBehaviour
    {
        protected IMatchManager m_Manager;

        protected IBlow m_Blow;
        protected IHead m_Head;

        protected IBall m_Ball = null;

        public int id { get; protected set; }

        public void Initialize(IMatchManager manager, int id, IBall ball)
        {
            this.id = id;

            m_Manager = manager ?? throw new System.NullReferenceException();

            m_Ball = ball ?? throw new System.NullReferenceException();

            m_Head = DefineHead();

            m_Blow = DefineBlow();

            OnInitialiazed();
        }

        protected abstract void OnInitialiazed();

        protected abstract IBlow DefineBlow();

        protected abstract IHead DefineHead();

        public virtual bool MakeBlow()
        {
            if (!m_Blow.isEnable) return false;

            Vector3 direction = (transform.position - m_Ball.position);
            float magnitude = direction.magnitude;
            direction = -new Vector3(direction.x, 0, direction.z) / magnitude;

            bool isBlowing = m_Blow.TryGetBlowForce(direction, magnitude, out Vector3 blowResult);
            if (isBlowing == false) return false;

            m_Ball.AddForce(blowResult);

            m_Head.LookAt(direction);
            m_Head.OnBlowed();
            return true;
        }
    }
}

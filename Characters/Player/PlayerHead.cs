
namespace Main
{
    [System.Serializable]
    public class PlayerHead : Head
    {
        public override void OnGamePause(bool isPause)
        {

        }

        public override void OnGoalMaded()
        {
            //m_Animator.Play("Goal", 0, 0.25f);
            //m_Animator.Play("Failed", 0, 0.25f);
        }
    }
}

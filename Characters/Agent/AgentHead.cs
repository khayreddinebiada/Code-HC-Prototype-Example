namespace Main
{
    [System.Serializable]
    public class AgentHead : Head
    {
        public override void OnGamePause(bool isPause)
        {
            //m_Animator.Play("Idle", 0, 0.25f);
        }

        public override void OnGoalMaded()
        {
            //m_Animator.Play("Goal", 0, 0.25f);

            //m_Animator.Play("Failed", 0, 0.25f);
        }
    }
}

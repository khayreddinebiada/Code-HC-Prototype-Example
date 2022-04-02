namespace Main
{
    public interface IMatchManager
    {
        void ExecuteGoalMade();

        void ExecutePause(bool isPause);

        void SubscribeGoalHandler(IGoalHandler goalHandler);

        void SubscribeGamePauser(IGamePause gamePause);
    }
}

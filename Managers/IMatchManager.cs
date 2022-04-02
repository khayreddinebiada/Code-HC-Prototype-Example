namespace Main
{
    public interface IGoalHandler
    {
        void OnGoalMaded();
    }

    public interface IMatchManager
    {
        void ExecuteGoalMade();

        void Subscribe(IGoalHandler goalHandler);
    }
}

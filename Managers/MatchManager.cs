using Engine.Events;

namespace Main
{
    public partial class MatchManager : Engine.DI.HighOrderBehaviour, IMatchManager
    {
        public InterfaceEvent<IGoalHandler> goalEvents => new InterfaceEvent<IGoalHandler>();

        private void Awake()
        {
            Engine.DI.DIContainer.RegisterAsSingle<IMatchManager>(this);
        }

        public void ExecuteGoalMade()
        {
            goalEvents.Invoke(madeGoal => madeGoal.OnGoalMaded());
        }

        public void Subscribe(IGoalHandler goalEvent)
        {
            goalEvents.Subscribe(goalEvent ?? throw new System.ArgumentNullException());
        }
    }
}

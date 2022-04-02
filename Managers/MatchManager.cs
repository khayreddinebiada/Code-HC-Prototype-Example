using Engine.Events;

namespace Main
{
    public partial class MatchManager : Engine.DI.HighOrderBehaviour, IMatchManager
    {
        private InterfaceEvent<IGoalHandler> goalEvents => new InterfaceEvent<IGoalHandler>();
        private InterfaceEvent<IGamePause> gamePauseEvents => new InterfaceEvent<IGamePause>();

        private void Awake()
        {
            Engine.DI.DIContainer.RegisterAsSingle<IMatchManager>(this);
        }

        public void ExecuteGoalMade()
        {
            goalEvents.Invoke(madeGoal => madeGoal.OnGoalMaded());
        }

        public void ExecutePause(bool isPause)
        {
            gamePauseEvents.Invoke(gamePause => gamePause.OnGamePause(isPause));
        }

        public void SubscribeGoalHandler(IGoalHandler goalEvent)
        {
            goalEvents.Subscribe(goalEvent ?? throw new System.ArgumentNullException());
        }

        public void SubscribeGamePauser(IGamePause gamePause)
        {
            gamePauseEvents.Subscribe(gamePause ?? throw new System.ArgumentNullException());
        }
    }
}

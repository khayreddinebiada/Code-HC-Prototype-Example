using Engine;

namespace Main
{
    public class LevelStatueCompleted : GameStatue<ILevelCompleted>
    {
        public override void Start()
        {
            Input.ControllerInputs.s_EnableInputs = false;

            Invoke(item => item.LevelCompleted());
        }
    }
}
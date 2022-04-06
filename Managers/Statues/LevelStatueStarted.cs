using Engine;

namespace Main
{
    public class LevelStatueStarted : GameStatue<ILevelStarted>
    {
        public override void Start()
        {
            Input.ControllerInputs.s_EnableInputs = true;

            Invoke(item => item.LevelStarted());
        }
    }
}
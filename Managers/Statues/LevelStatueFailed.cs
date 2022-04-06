using Engine;

namespace Main
{
    public class LevelStatueFailed : GameStatue<ILevelFailed>
    {
        public override void Start()
        {
            Input.ControllerInputs.s_EnableInputs = false;

            Invoke(item => item.LevelFailed());
        }
    }
}
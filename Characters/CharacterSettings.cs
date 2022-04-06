using UnityEngine;

namespace Main
{
    public enum AgentDifficulty { Easy, Medium, Hard }

    [CreateAssetMenu(fileName = "New Character Settings", menuName = "Add/More/Character Settings", order = 10)]
    public class CharacterSettings : ScriptableObject
    {
        public PlayerBlow PlayerBlow;
        public AgentBlow[] AgentBlow;

        public EasyBrain easyBrain;
        public MeduimBrain mediumBrain;
        public HardBrain hardBrain;
    }
}

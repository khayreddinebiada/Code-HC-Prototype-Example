using UnityEngine;

namespace Main
{
    [CreateAssetMenu(fileName = "New Character Settings", menuName = "Add/More/Character Settings", order = 10)]
    public class CharacterSettings : ScriptableObject
    {
        public PlayerBlow PlayerBlow;
        public AgentBlow AgentBlow;
    }
}

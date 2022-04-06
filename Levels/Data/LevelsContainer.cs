using Engine;
using UnityEngine;

namespace Main.Level
{
    [CreateAssetMenu(fileName = "New Levels Container", menuName = "Add/More/Levels Container", order = 10)]
    public partial class LevelsContainer : Engine.DI.HighOrderScriptableObject, IAwake
    {
        [System.Serializable]
        public struct LevelsGroup : ILevelGroup
        {
            [Header("Levels")]
            [SerializeField] private Level[] _levels;

            public int totalLevels => _levels.Length;

            public Level GetLevelPrefab(int idLevel)
            {
                if ((uint)_levels.Length <= (uint)idLevel) throw new System.ArgumentOutOfRangeException();
                return _levels[idLevel];
            }
        }

        [SerializeField] private LevelsGroup[] m_LevelsGroup;

        public void Awake()
        {
            Engine.DI.DIContainer.RegisterAsSingle<ILevelGroup>(m_LevelsGroup[0]);
        }
    }
}

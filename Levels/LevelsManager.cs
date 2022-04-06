using Engine.DI;
using UnityEngine;

namespace Main.Level
{
    public partial class LevelsManager : HighOrderBehaviour, ILevelsManager
    {
        [SerializeField] private Transform _levelsContents;
        
        private ILevelsData m_LevelData;
        private ILevelGroup m_LevelContainer;

        public int totalLevels
        {
            get 
            {
                if (m_LevelContainer == null) m_LevelContainer = DIContainer.GetAsSingle<ILevelGroup>() ?? throw new System.NullReferenceException();
                return m_LevelContainer.totalLevels;
            }
        }

        public Level level { get; private set; }

        public LevelInfoSO levelInfo
        {
            get
            {
                if (isLevelLoaded) return level.levelInfo;

                return null;
            }
        }

        public bool isLevelLoaded { get; private set; } = false;

        private void Awake()
        {
            DIContainer.RegisterAsSingle<ILevelsManager>(this);
        }

        private void Start()
        {
            m_LevelContainer = DIContainer.GetAsSingle<ILevelGroup>() ?? throw new System.NullReferenceException();
            m_LevelData = DIContainer.GetAsSingle<ILevelsData>() ?? throw new System.NullReferenceException();

            InitializeLevel();
        }

        private void InitializeLevel()
        {
            if (m_LevelData.isTestingMode)
            {
                /// Note: This call just on unity editor testing.
                level = FindObjectOfType<Level>();
                if (level != null)
                {
                    DefineCurrentLevel(level);
                    return;
                }

                MakeInstantiate();
                return;
            }

            MakeInstantiate();
        }

        private void MakeInstantiate()
        {
            level = m_LevelContainer.GetLevelPrefab(m_LevelData.idLevel) ?? throw new System.NullReferenceException("Level has a null value!...");
            DefineCurrentLevel(Instantiate(level, _levelsContents));
        }

        private void DefineCurrentLevel(Level level)
        {
            level = level ?? throw new System.ArgumentNullException();

            level.Initialize(this);

            isLevelLoaded = true;
        }
    }
}

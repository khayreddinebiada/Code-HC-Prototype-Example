using UnityEngine;

namespace main
{
    public sealed class MatchCreator : MonoBehaviour
    {
        [System.Serializable]
        public struct MatchInfo
        {
            public Vector3[] positions;
            public int totalPlayers => positions.Length;
        }

        [Header("Info")]
        [SerializeField] private MatchInfo m_PlayerInfo;
        [SerializeField] private MatchInfo m_EnemyInfo;

        [Header("Objects")]
        [SerializeField] private Ball m_Ball;

        [Header("Players")]
        [SerializeField] private Player m_PlayerPrefab;
        [SerializeField] private Enemy m_EnemyPrefab;

        private void OnEnable()
        {
            CreateMatch();
        }

        private void CreateMatch()
        {
            for (int i = 0; i < m_PlayerInfo.totalPlayers; i++)
            {
                Instantiate(m_PlayerPrefab, m_PlayerInfo.positions[i], Quaternion.identity).Initialize(m_Ball);
            }

            for (int i = 0; i < m_EnemyInfo.totalPlayers; i++)
            {
                Instantiate(m_EnemyPrefab, m_EnemyInfo.positions[i], new Quaternion(0, 0, 1, 0)).Initialize(m_Ball);
            }
        }

#if UNITY_EDITOR
        [NaughtyAttributes.Button("Fill Match Info")]
        public void GenerateMatchInfo()
        {
            Player[] players = gameObject.GetComponentsInChildren<Player>();
            Enemy[] enemies = gameObject.GetComponentsInChildren<Enemy>();

            if (players.Length == 0 || enemies.Length == 0) return;

            m_PlayerInfo.positions = new Vector3[players.Length];
            m_EnemyInfo.positions = new Vector3[enemies.Length];

            for (int i = 0; i < m_PlayerInfo.totalPlayers; i++)
                m_PlayerInfo.positions[i] = players[i].transform.position;

            for (int i = 0; i < m_EnemyInfo.totalPlayers; i++)
                m_EnemyInfo.positions[i] = enemies[i].transform.position;
        }
#endif
    }
}
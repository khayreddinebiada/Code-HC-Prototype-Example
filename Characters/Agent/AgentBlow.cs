﻿using UnityEngine;

namespace Main
{
    [System.Serializable]
    public struct AgentBlow : IBlow
    {
        public float m_ForceValue;
        public float m_Radio;

        public bool isEnable { get; set; }

        public Vector3 BlowForce(Vector3 direction, float sqrMagnitude)
        {
            if (sqrMagnitude <= m_Radio) return direction * m_ForceValue;

            return Vector3.zero;
        }

        public void MakePause(bool isPause)
        {

        }

        public void OnGamePause(bool isPause)
        {

        }
    }
}
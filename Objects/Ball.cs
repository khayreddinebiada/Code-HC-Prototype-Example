﻿using UnityEngine;

namespace Main
{
    public class Ball : Engine.DI.HighOrderBehaviour, IBall
    {
        [SerializeField] private Rigidbody m_Rigidbody;

        public Vector3 position => transform.position;

        public Vector3 velocity => m_Rigidbody.velocity;

        private void Awake()
        {
            Engine.DI.DIContainer.RegisterAsSingle<IBall>(this);
        }

        public void AddForce(Vector3 force)
        {
            m_Rigidbody.velocity += force;
        }
    }
}

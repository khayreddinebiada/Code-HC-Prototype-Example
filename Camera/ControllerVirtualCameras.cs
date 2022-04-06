using System.Collections.Generic;
using UnityEngine;

namespace Engine.Camera
{
    public class ControllerVirtualCameras : DI.HighOrderBehaviour
    {
        [SerializeField] private UnityEngine.Camera m_InitCamera;

        [SerializeField] private string m_DefaultSwitch = "Default";
        [SerializeField] private List<CameraView> m_Views;

        private IVirtualCamerasManager m_VirtualCamerasManager;

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            DI.DIContainer.RegisterAsSingle(m_InitCamera);

            m_VirtualCamerasManager = DI.DIContainer.GetAsSingle<IVirtualCamerasManager>();

            m_VirtualCamerasManager.AddCameraView(m_Views.ToArray());
            m_VirtualCamerasManager.SwitchTo(m_DefaultSwitch);
        }

        protected void OnDestroy()
        {
            m_VirtualCamerasManager.Deinitialize();
        }
    }
}

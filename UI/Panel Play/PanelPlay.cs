using System;
using System.Collections;
using UnityEngine;

namespace Main.UI
{
    public class PanelPlay : Panel, IGoalHandler
    {
        [SerializeField] private TMPro.TextMeshProUGUI m_TimeLeft;
        [SerializeField] private GameObject m_Goal;
        
        private IMatchManager m_MatchManager;

        protected void OnEnable()
        {
            m_MatchManager = Engine.DI.DIContainer.GetAsSingle<IMatchManager>();

            m_MatchManager.SubscribeGoalHandler(this);

            LevelStarted();
        }

        private void LevelStarted()
        {
            StartTimer(() => { m_MatchManager.ExecutePause(false); });
        }

        public void OnGoalMaded()
        {
            m_MatchManager.ExecutePause(true);

            m_Goal.SetActive(true);

            StartCoroutine(WaitAndStartTimer());
        }

        private IEnumerator WaitAndStartTimer()
        {
            yield return new WaitForSeconds(1);

            m_Goal.SetActive(false);
            StartTimer(() => { m_MatchManager.ExecutePause(false); });
        }


        private void StartTimer(Action onTimerEnd)
        {
            m_TimeLeft.gameObject.SetActive(true);
            StartCoroutine(TimeUpdate(onTimerEnd, 2));
        }

        private IEnumerator TimeUpdate(Action onTimerEnd, int timeLeft)
        {
            m_TimeLeft.text = timeLeft.ToString();

            yield return new WaitForSeconds(1);

            timeLeft--;

            if (timeLeft < 0)
            {
                onTimerEnd?.Invoke();
                m_TimeLeft.gameObject.SetActive(false);
            }
            else StartCoroutine(TimeUpdate(onTimerEnd, timeLeft));
        }

        public void ReloadScene()
        {
            GameScenes.ReloadScene();
        }
    }
}

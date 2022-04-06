using Engine.Coin;
using UnityEngine;

namespace Main.UI.Coin
{
    public class TotalCoinsCountText : TotalCoinsText
    {
        [Header("Counter")]
        [Range(0.1f, 10f)] [SerializeField] private float _timeCounting = 1;
        [Range(0.03f, 0.4f)] [SerializeField] private float _smouth = 0.1f;

        protected CoinsCounter m_Counter;

        protected override void OnEnable()
        {
            m_Counter = new CoinsCounter(_textTotalCoins, m_CoinsInfo.totalCoins, _timeCounting, _smouth);
            base.OnEnable();
        }

        protected override void OnUpdateCoins(ParametersUpdate data)
        {
            if (data.operation == OperationType.Add)
                m_Counter.UpdateCount(data.total, data.amount);
            else
            if (data.operation == OperationType.Minus)
                m_Counter.UpdateCount(data.total, -data.amount);
        }
    }
}